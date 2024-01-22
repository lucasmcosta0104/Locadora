using Locadora.Infra;
using Locadora.Interface;
using Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Repository
{
    public class LocacaoRepository : IRepository<Locacao>
    {
        private readonly ApplicationDbContext _context;

        public LocacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Locacao entity, CancellationToken cancellationToken)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<ICollection<Locacao>> All(CancellationToken cancellationToken)
        {
            return await _context.Locacao.ToListAsync(cancellationToken);
        }

        public async Task Delete(Locacao entity, CancellationToken cancellationToken)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Locacao> Find(int id, CancellationToken cancellationToken)
        {
            return await _context.Locacao
                .Include(x => x.Veiculo)
                .Include(x => x.Cliente)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task Update(Locacao entity, CancellationToken cancellationToken)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<Locacao> Find()
        {
            return _context.Locacao;
        }
    }
}
