using Locadora.Dto;
using Locadora.Interface;
using Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Services
{
    public class VeiculoService
    {
        private readonly IRepository<Veiculo> _repository;
        public VeiculoService(IRepository<Veiculo> repository)
        {
            _repository = repository;
        }

        public async Task<string> Adicionar(VeiculoDto dto, CancellationToken cancellationToken)
        {
            var veiculos = await _repository.All(cancellationToken);

            if(veiculos.Any(x => x.Placa == dto.Placa))
            {
                throw new Exception($"Veiculo com a placa {dto.Placa} já existe.");
            }

            var veiculo = new Veiculo();
            await veiculo.Adicionar(dto);
            await _repository.Add(veiculo, cancellationToken);
            return $"Veiculo {veiculo.Marca} {veiculo.Modelo} {veiculo.Placa} foi adicionado com sucesso";
        }

        public async Task<ICollection<Veiculo>> BuscaCompleta(int idLocadora, CancellationToken cancellationToken)
        {
            return await _repository.Find()
                .Where(x => x.LocadoraModeloId == idLocadora)
                .ToListAsync(cancellationToken);
        }

        public async Task<Veiculo> Buscar(int id, CancellationToken cancellationToken)
        {
            var veiculo = await _repository.Find(id, cancellationToken);
            if (veiculo == null)
                throw new Exception("Veiculo não encontrado");

            return veiculo;
        }

        public async Task<string> Editar(int id, VeiculoEditDto dto, CancellationToken cancellationToken)
        {
            var veiculo = await _repository.Find(id, cancellationToken);
            if (veiculo == null)
                throw new Exception("Veiculo não encontrado");
            await veiculo.Editar(dto);
            await _repository.Update(veiculo, cancellationToken);
            return $"Veiculo {veiculo.Marca} {veiculo.Modelo} {veiculo.Placa} foi alterado com sucesso";
        }

        public async Task<string> Remover(int id, CancellationToken cancellationToken)
        {
            var veiculo = await _repository.Find(id, cancellationToken);
            if (veiculo == null)
                throw new Exception("Veiculo não encontrado");

            await _repository.Delete(veiculo, cancellationToken);
            return $"Veiculo {veiculo.Marca} {veiculo.Modelo} {veiculo.Placa} foi removido com sucesso";
        }
    }
}
