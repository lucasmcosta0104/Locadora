using Locadora.Infra;
using Locadora.Interface;
using Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Repository
{
    public class VeiculoRepository : IRepository<Veiculo>
    {
        private readonly ApplicationDbContext _context;

        public VeiculoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Veiculo entity, CancellationToken cancellationToken)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<ICollection<Veiculo>> All(CancellationToken cancellationToken)
        {
            return await _context.Veiculo.ToListAsync(cancellationToken);
        }

        public async Task Delete(Veiculo entity, CancellationToken cancellationToken)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Veiculo> Find(int id, CancellationToken cancellationToken)
        {
            return await _context.Veiculo.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Veiculo entity, CancellationToken cancellationToken)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
