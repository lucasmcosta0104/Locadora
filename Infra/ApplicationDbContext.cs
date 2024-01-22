using Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<LocadoraModelo> LocadoraModelo { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Locacao> Locacao { get; set; }
    }
}
