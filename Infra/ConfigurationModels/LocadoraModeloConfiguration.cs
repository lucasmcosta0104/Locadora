using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.ConfigurationModels
{
    public class LocadoraModeloConfiguration : IEntityTypeConfiguration<LocadoraModelo>
    {
        public void Configure(EntityTypeBuilder<LocadoraModelo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
        }
    }
}
