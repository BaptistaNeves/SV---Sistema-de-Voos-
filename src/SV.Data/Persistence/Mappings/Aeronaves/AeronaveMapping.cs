using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Core.Entities.Aeronaves;

namespace SV.Data.Persistence.Mappings.Aeronaves
{
    public class AeronaveMapping : IEntityTypeConfiguration<Aeronave>
    {
        public void Configure(EntityTypeBuilder<Aeronave> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Modelo)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.Fabricante)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.TotalDeAssentos)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(a => a.Activo)
                .HasColumnType("bit");

            builder.HasMany(a => a.Assentos)
                .WithOne(a => a.Aeronave)
                .HasForeignKey(a => a.AeronaveId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Aeronaves");
        }
    }
}
