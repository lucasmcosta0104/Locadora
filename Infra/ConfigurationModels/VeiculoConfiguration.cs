using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.ConfigurationModels
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.LocadoraModelo)
                .WithMany(x => x.Veiculos)
                .HasForeignKey(x => x.LocadoraModeloId);

            builder.Property(x => x.ValorDiaria).HasColumnType("decimal(17,2)");
        }
    }
}
