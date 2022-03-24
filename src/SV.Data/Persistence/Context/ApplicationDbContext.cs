using Microsoft.EntityFrameworkCore;
using SV.Core.Entities.Aeronaves;
using SV.Core.Entities.Aeroportos;
using SV.Core.Entities.Cidades;

namespace SV.Data.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Assento> Assentos { get; set; }
        public DbSet<Aeronave> Aeronaves { get; set; }
        public DbSet<Aeroporto> Aeroportos { get; set; }
        public DbSet<Classe> Classes { get; set; }
    }
}
