using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Core.Entities.Aeronaves;

namespace SV.Data.Persistence.Mappings.Aeronaves
{
    public class ClasseMapping : IEntityTypeConfiguration<Classe>
    {
        public void Configure(EntityTypeBuilder<Classe> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasMany(c => c.Assentos)
                .WithOne(a => a.Classe)
                .HasForeignKey(a => a.ClasseId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.ToTable("Classes");
        }
    }
}
