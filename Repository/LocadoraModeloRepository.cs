using Locadora.Infra;
using Locadora.Interface;
using Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Repository
{
    public class LocadoraModeloRepository : IRepository<LocadoraModelo>
    {
        private readonly ApplicationDbContext _context;
        public LocadoraModeloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(LocadoraModelo entity, CancellationToken cancellationToken)
        {
            _context.LocadoraModelo.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<ICollection<LocadoraModelo>> All(CancellationToken cancellationToken)
        {
            return await _context.LocadoraModelo.ToListAsync(cancellationToken);
        }

        public async Task Delete(LocadoraModelo entity, CancellationToken cancellationToken)
        {
            _context.LocadoraModelo.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<LocadoraModelo> Find(int id, CancellationToken cancellationToken)
        {
            return await _context.LocadoraModelo.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task Update(LocadoraModelo entity, CancellationToken cancellationToken)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<LocadoraModelo> Find()
        {
            return _context.LocadoraModelo;
        }
    }
}
