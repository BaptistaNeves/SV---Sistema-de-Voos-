using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Data.Persistence.Models.Usuarios;

namespace SV.Data.Persistence.Mappings.Usuarios
{
    public class UsuarioMapping : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(c => c.NomeDeUtilizador)
                 .HasColumnType("varchar(100)");
        }

    }
}
