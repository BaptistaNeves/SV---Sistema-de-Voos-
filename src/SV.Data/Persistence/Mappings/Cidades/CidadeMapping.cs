using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Core.Entities.Cidades;

namespace SV.Data.Persistence.Mappings.Cidades
{
    public class CidadeMapping : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(max)");

            builder.Property(c => c.Pais)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasMany(c => c.Aeroportos)
                .WithOne(a => a.Cidade)
                .HasForeignKey(a => a.CidadeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.ToTable("Cidades");
            
        }
    }
}
