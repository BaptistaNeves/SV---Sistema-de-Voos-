using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Core.Entities.Funcionarios;

namespace SV.Data.Persistence.Mappings.Funcionarios
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(f => f.DataNascimento)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(f => f.Naturalidade)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(f => f.Nacionalidade)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(f => f.Documento)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(f => f.NumeroDocumento)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(f => f.AreaAcademica)
                .HasColumnType("varchar(50)");

            builder.Property(f => f.NivelAcademico)
                .HasColumnType("varchar(50)");

            builder.Property(f => f.Telefone)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(f => f.Email)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(f => f.Endereco)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(f => f.Sexo)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(f => f.EstadoCivil)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(f => f.Imagem)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(f => f.Ativo)
                .HasColumnType("bit");

            builder.Property(f => f.Observacao)
                .HasColumnType("varchar(max)");

            builder.ToTable("Funcionarios");
        }
    }
}
