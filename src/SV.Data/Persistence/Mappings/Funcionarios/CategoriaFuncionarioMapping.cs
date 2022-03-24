using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Core.Entities.Funcionarios;

namespace SV.Data.Persistence.Mappings.Funcionarios
{
    public class CategoriaFuncionarioMapping : IEntityTypeConfiguration<CategoriaFuncionario>
    {
        public void Configure(EntityTypeBuilder<CategoriaFuncionario> builder)
        {
            builder.HasKey(cf => cf.Id);

            builder.Property(cf => cf.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(cf => cf.Descricao)
                .HasColumnType("varchar(max)");

            builder.HasMany(cf => cf.Funcionarios)
                .WithOne(f => f.CategoriaFuncionario)
                .HasForeignKey(f => f.CategoriaFuncionarioId);

            builder.ToTable("CategoriasFuncionario");
        }
    }
}
