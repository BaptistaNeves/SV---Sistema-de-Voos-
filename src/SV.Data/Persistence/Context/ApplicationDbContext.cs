using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SV.Core.Entities.Aeronaves;
using SV.Core.Entities.Aeroportos;
using SV.Core.Entities.Cidades;
using SV.Core.Entities.Funcionarios;
using SV.Core.Entities.Voos;
using SV.Data.Persistence.Models.Usuarios;
using System;

namespace SV.Data.Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid,
                                IdentityUserClaim<Guid>, AppUserRole, IdentityUserLogin<Guid>, 
                                IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<AppRole>()
                      .HasMany(r => r.UserRoles)
                      .WithOne(ur => ur.Role)
                      .HasForeignKey(ur => ur.RoleId)
                      .IsRequired();

            modelBuilder.Entity<AppUser>()
                       .HasMany(u => u.UserRoles)
                       .WithOne(ur => ur.User)
                       .HasForeignKey(ur => ur.UserId)
                       .IsRequired();

        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Assento> Assentos { get; set; }
        public DbSet<Aeronave> Aeronaves { get; set; }
        public DbSet<Aeroporto> Aeroportos { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<CategoriaFuncionario> CategoriasFuncionario { get; set; }

        public DbSet<TipoDeVoo> TiposDeVoo { get; set; }
        public DbSet<Voo> Voos { get; set; }

    }
}
