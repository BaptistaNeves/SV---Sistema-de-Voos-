using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Core.Entities.Aeroportos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV.Data.Persistence.Mappings.Aeroportos
{
    public class AeroportoMapping : IEntityTypeConfiguration<Aeroporto>
    {
        public void Configure(EntityTypeBuilder<Aeroporto> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(a => a.CidadeId)
                .IsRequired();

            builder.Property(a => a.Activo)
                .HasColumnType("bit");

            builder.ToTable("Aeroportos");
        }
    }
}
