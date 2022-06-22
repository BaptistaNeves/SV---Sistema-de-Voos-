using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Core.Entities.Aeronaves;

namespace SV.Data.Persistence.Mappings.Aeronaves
{
    public class AssentoMapping : IEntityTypeConfiguration<Assento>
    {
        public void Configure(EntityTypeBuilder<Assento> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Numero)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(a => a.Status)
               .HasColumnType("bit");

            builder.Property(a => a.VooId)
                .IsRequired();

            builder.Property(a => a.ClasseId)
                .IsRequired();

            builder.ToTable("Assentos");
        }
    }
}
