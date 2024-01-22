using Locadora.Dto;
using Locadora.Interface;
using Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Services
{
    public class ClienteService
    {
        private readonly IRepository<Cliente> _repository;

        public ClienteService(IRepository<Cliente> repository)
        {
            _repository = repository;
        }

        public async Task<string> Adicionar(ClienteDto dto, CancellationToken cancellationToken)
        {
            var cliente = new Cliente();
            await cliente.Adicionar(dto);
            await _repository.Add(cliente, cancellationToken);
            return $"Cliente {cliente.Nome} foi adicionado com sucesso";
        }

        public async Task<string> Bloquear(int id, CancellationToken cancellationToken)
        {
            var cliente = await _repository.Find(id, cancellationToken);
            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            await cliente.Bloquear();
            await _repository.Update(cliente, cancellationToken);
            return $"Cliente {cliente.Nome} foi bloqueado";
        }

        public async Task<ICollection<Cliente>> BuscaCompleta(int idLocadora, CancellationToken cancellationToken)
        {
            return await _repository.Find()
                .Where(x => x.LocadoraModeloId == idLocadora)
                .ToListAsync(cancellationToken);
        }

        public async Task<Cliente> Buscar(int id, CancellationToken cancellationToken)
        {
            var cliente = await _repository.Find(id, cancellationToken);
            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            return cliente;
        }

        public async Task<string> Desbloquear(int id, CancellationToken cancellationToken)
        {
            var cliente = await _repository.Find(id, cancellationToken);
            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            await cliente.Desbloquear();
            await _repository.Update(cliente, cancellationToken);
            return $"Cliente {cliente.Nome} foi desbloqueado";
        }

        public async Task<string> Editar(int id, ClienteUpdateDto dto, CancellationToken cancellationToken)
        {
            var cliente = await _repository.Find(id, cancellationToken);
            if (cliente == null)
                throw new Exception("Cliente não encontrado");
            await cliente.Editar(dto);
            await _repository.Update(cliente, cancellationToken);
            return $"Cliente {cliente.Nome} foi alterado com sucesso";
        }

        public async Task<string> Remover(int id, CancellationToken cancellationToken)
        {
            var cliente = await _repository.Find(id, cancellationToken);
            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            await _repository.Delete(cliente, cancellationToken);
            return $"Cliente {cliente.Nome} foi removido com sucesso";
        }
    }
}
