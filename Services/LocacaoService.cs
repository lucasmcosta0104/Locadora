using Locadora.Dto;
using Locadora.Interface;
using Locadora.Migrations;
using Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Services
{
    public class LocacaoService
    {
        private readonly IRepository<Locacao> _repository;
        private readonly VeiculoService _veiculoService;
        private readonly ClienteService _clienteService;

        public LocacaoService(IRepository<Locacao> repository, VeiculoService veiculoService, ClienteService clienteService)
        {
            _repository = repository;
            _veiculoService = veiculoService;
            _clienteService = clienteService;
        }

        public async Task<string> Alugar(LocacaoDto dto, CancellationToken cancellationToken)
        {
            var veiculo = await _veiculoService.Buscar(dto.VeiculoId, cancellationToken);
            var cliente = await _clienteService.Buscar(dto.ClienteId, cancellationToken);
            if (veiculo == null) 
            {
                return $"Veículo não encontrado, por favor informe o veículo correto";
            }
            
            if (cliente == null) 
            {
                return $"Cliente não encontrado, por favor cadastrar ou informar um cliente cadastro.";
            }

            if (!veiculo.Disponibilidade)
            {
                return $"Veículo {veiculo.Marca} {veiculo.Modelo} {veiculo.Placa} não está disponível para locação";
            }
            var locacao = new Locacao();
            await locacao.Alugar(dto);
            await veiculo.RetiradaLocacao();
            await _repository.Add(locacao, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return $"Veículo {veiculo.RetornaMarcaModeloPlacaVeiculo()} foi alugado com succeso para o Cliente {cliente.Nome}";
        }

        public async Task<ICollection<LocacaoViewDto>> BuscaCompleta(int idLocadora, CancellationToken cancellationToken)
        {
            var listLocacaoDto = await _repository.Find()
                .Where(x => x.LocadoraModeloId == idLocadora)
                .Select(x => new LocacaoViewDto
                {
                    Id = x.Id,
                    DataEntrega = x.DataEntrega,
                    DataRetirada = x.DataRetirada,
                    QuantidadeDiarias = x.QuantidadeDiarias,
                    QuantidaDiariaMulta = x.QuantidaDiariaMulta,
                    LocadoraModeloId = x.LocadoraModeloId,
                    Observacao = x.Observacao,
                    Veiculo = x.Veiculo.RetornaMarcaModeloPlacaVeiculo(),
                    Cliente = x.Cliente.Nome,
                    VeiculoId = x.VeiculoId,
                    ClienteId = x.ClienteId
                }).ToListAsync(cancellationToken);

            return listLocacaoDto;
        }

        public async Task<LocacaoViewDto> Buscar(int id, CancellationToken cancellationToken)
        {
            var locacao = await _repository.Find(id, cancellationToken);
            if (locacao == null)    
                throw new ArgumentNullException(nameof(locacao), "Locação não encontrada, solicitar suporte.");
            
            return RetornarLocacaoDto(locacao);
        }

        public async Task<string> Entregar(int id, CancellationToken cancellationToken)
        {
            var locacao = await _repository.Find(id, cancellationToken);
            if (locacao == null)
                throw new ArgumentNullException(nameof(locacao), "Locação não encontrada, solicitar suporte.");

            if (locacao.DataEntrega > locacao.DataRetirada)
                return $"Veículo consta como entregue no sistema, verificar com gerente";

            var diarias = locacao.Entregar();
            await locacao.Veiculo.EntregaLocacao();
            var valorTotal = locacao.Veiculo.CalcularValorTotalLocacao(diarias, locacao.QuantidaDiariaMulta);
            await _repository.SaveChangesAsync(cancellationToken);
            return $"O valor total da locação do veículo {locacao.Veiculo.RetornaMarcaModeloPlacaVeiculo()} foi de {valorTotal.ToString("C")}";
        }

        private LocacaoViewDto RetornarLocacaoDto(Locacao locacao)
        {
            return new LocacaoViewDto
            {
                Id = locacao.Id,
                DataEntrega = locacao.DataEntrega,
                DataRetirada = locacao.DataRetirada,
                QuantidadeDiarias = locacao.QuantidadeDiarias,
                QuantidaDiariaMulta = locacao.QuantidaDiariaMulta,
                LocadoraModeloId = locacao.LocadoraModeloId,
                Observacao = locacao.Observacao,
                Veiculo = locacao.Veiculo.RetornaMarcaModeloPlacaVeiculo(),
                Cliente = locacao.Cliente.Nome,
                VeiculoId = locacao.VeiculoId,
                ClienteId = locacao.ClienteId
            };
        }
    }
}
