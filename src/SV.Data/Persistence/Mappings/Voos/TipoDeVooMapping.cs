using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Core.Entities.Voos;

namespace SV.Data.Persistence.Mappings.Voos
{
    public class TipoDeVooMapping : IEntityTypeConfiguration<TipoDeVoo>
    {
        public void Configure(EntityTypeBuilder<TipoDeVoo> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(t => t.Descricao)
               .HasColumnType("varchar(max)");

            builder.HasMany(t => t.Voos)
                .WithOne(v => v.TipoDeVoo)
                .HasForeignKey(v => v.TipoDeVooId);

            builder.ToTable("TiposDeVoo");
        }
    }
}
