using Locadora.Infra;
using Locadora.Interface;
using Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Repository
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Usuario usuario, CancellationToken cancellationToken)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<ICollection<Usuario>> All(CancellationToken cancellationToken)
        {
            return await _context.Usuario.ToListAsync(cancellationToken);
        }

        public async Task Delete(Usuario usuario, CancellationToken cancellationToken)
        {
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Usuario> Find(int id, CancellationToken cancellationToken)
        {
            return await _context.Usuario.FindAsync(id, cancellationToken);
        }

        public async Task Update(Usuario usuario, CancellationToken cancellationToken)
        {
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<Usuario> Find()
        {
            return _context.Usuario;
        }
    }
}
