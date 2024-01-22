using Locadora.Infra;
using Locadora.Interface;
using Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Repository
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Cliente entity, CancellationToken cancellationToken)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Cliente>> All(CancellationToken cancellationToken)
        {
            return await _context.Cliente.ToListAsync(cancellationToken);
        }

        public async Task Delete(Cliente entity, CancellationToken cancellationToken)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Cliente> Find(int id, CancellationToken cancellationToken)
        {
            return await _context.Cliente.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task Update(Cliente entity, CancellationToken cancellationToken)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
