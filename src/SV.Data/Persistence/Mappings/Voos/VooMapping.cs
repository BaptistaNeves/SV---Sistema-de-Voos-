using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Core.Entities.Voos;

namespace SV.Data.Persistence.Mappings.Voos
{
    public class VooMapping : IEntityTypeConfiguration<Voo>
    {
        public void Configure(EntityTypeBuilder<Voo> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.TipoDeVooId)
                .IsRequired();

            builder.Property(t => t.AeronaveId)
               .IsRequired();

            builder.Property(t => t.AeroportoDeOrigem)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(t => t.AeroportoDestino)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(t => t.DataDePartida)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(t => t.HoraDePartida)
               .IsRequired()
               .HasColumnType("datetime2");

            builder.Property(t => t.PrevisaoDeChegada)
               .IsRequired()
               .HasColumnType("datetime2");

            builder.Property(t => t.PrevisaoDeChegadaAoDestino)
               .IsRequired()
               .HasColumnType("datetime2");

            builder.Property(t => t.Descricao)
               .IsRequired()
               .HasColumnType("varchar(255)");

            builder.Property(t => t.Imagem)
               .IsRequired()
               .HasColumnType("varchar(255)");

            builder.Property(t => t.Estado)
              .IsRequired()
              .HasColumnType("bit");

            builder.Property(t => t.PrecoCusto)
              .IsRequired()
              .HasColumnType("decimal(18,2)");

            builder.HasMany(a => a.Assentos)
                .WithOne(a => a.Voo)
                .HasForeignKey(a => a.VooId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Reservas)
                .WithOne(a => a.Voo)
                .HasForeignKey(a => a.VooId);

            builder.ToTable("Voos");
        }
    }
}
