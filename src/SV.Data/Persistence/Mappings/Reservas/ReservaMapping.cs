using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Core.Entities.Reservas;

namespace SV.Data.Persistence.Mappings.Reservas
{
    public class ReservaMapping : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Preco)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Nome)
               .IsRequired()
               .HasColumnType("varchar(222)");

            builder.Property(x => x.TipoDocumento)
               .IsRequired()
               .HasColumnType("varchar(20)");

            builder.Property(x => x.NumeroDocumento)
               .IsRequired()
               .HasColumnType("varchar(225)");

            builder.Property(x => x.Email)
               .IsRequired()
               .HasColumnType("varchar(225)");

            builder.Property(x => x.Telefone)
               .IsRequired()
               .HasColumnType("varchar(20)");

            builder.Property(x => x.Sexo)
               .IsRequired()
               .HasColumnType("varchar(10)");

            builder.Property(x => x.Endereco)
              .IsRequired()
              .HasColumnType("varchar(500)");

            builder.Property(x => x.DataNascimento)
              .IsRequired()
              .HasColumnType("datetime2");

            builder.ToTable("Reservas");
        }
    }
}
