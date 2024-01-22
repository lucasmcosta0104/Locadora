using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.ConfigurationModels
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.LocadoraModelo)
                .WithMany(x => x.Clientes)
                .HasForeignKey(x => x.LocadoraModeloId);
        }
    }
}
