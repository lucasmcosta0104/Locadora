using Locadora.Dto;
using Locadora.Interface;
using Locadora.Models;

namespace Locadora.Services
{
    public class LocadoraModeloService
    {
        private readonly IRepository<LocadoraModelo> repository;

        public LocadoraModeloService(IRepository<LocadoraModelo> repository)
        {
            this.repository = repository;
        }

        public async Task Adicionar(LocadoraDto dto, CancellationToken cancellationToken)
        {
            var locadora = new LocadoraModelo();
            await locadora.Adicionar(dto);
            await repository.Add(locadora, cancellationToken);
        }

        public async Task<LocadoraModelo> Buscar(int id, CancellationToken cancellationToken)
        {
            var locadora = await repository.Find(id, cancellationToken);
            if (locadora == null)
                throw new Exception("Locadora não encontrada");
            return locadora;
        }

        public async Task Remover(int id, CancellationToken cancellationToken)
        {
            var locadora  = await repository.Find(id, cancellationToken);
            if (locadora == null)
                throw new Exception("Locadora não encontrada");

            await repository.Delete(locadora, cancellationToken);
        }

        public async Task Editar(int id, LocadoraDto dto, CancellationToken cancellationToken)
        {
            var locadora = await repository.Find(id, cancellationToken);
            if (locadora == null)
                throw new Exception("Locadora não encontrada");

            await locadora.Editar(dto);
            await repository.Update(locadora, cancellationToken);
        }

        public async Task<ICollection<LocadoraModelo>> BuscaCompleta(CancellationToken cancellationToken)
        {
            return await repository.All(cancellationToken);
        }
    }
}
