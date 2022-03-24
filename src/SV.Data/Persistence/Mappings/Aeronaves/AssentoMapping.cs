using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Core.Entities.Aeronaves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV.Data.Persistence.Mappings.Aeronaves
{
    public class AssentoMapping : IEntityTypeConfiguration<Assento>
    {
        public void Configure(EntityTypeBuilder<Assento> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Numero)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(a => a.AeronaveId)
                .IsRequired();

            builder.Property(a => a.ClasseId)
                .IsRequired();

            builder.ToTable("Assentos");
        }
    }
}
