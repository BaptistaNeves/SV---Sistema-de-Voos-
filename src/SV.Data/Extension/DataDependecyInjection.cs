using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SV.Core.Interfaces.Repositories.Aeronaves;
using SV.Core.Interfaces.Repositories.Aeroportos;
using SV.Core.Interfaces.Repositories.Cidades;
using SV.Core.Interfaces.Repositories.Funcionarios;
using SV.Core.Interfaces.Repositories.Usuarios;
using SV.Core.Interfaces.Repositories.Voos;
using SV.Data.Persistence.Context;
using SV.Data.Persistence.Models.Usuarios;
using SV.Data.Persistence.Repositories.Aeronaves;
using SV.Data.Persistence.Repositories.Aeroportos;
using SV.Data.Persistence.Repositories.Cidades;
using SV.Data.Persistence.Repositories.Funcionarios;
using SV.Data.Persistence.Repositories.Usuarios;
using SV.Data.Persistence.Repositories.Voos;
using System;

namespace SV.Data.Extension
{
    public static class DataDependecyInjection
    {
        public static IServiceCollection AddDataDependecyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ApplicationDbContext>();

            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IAeroportoRepository, AeroportoRepository>();
            services.AddScoped<IClasseRepository, ClasseRepository>();
            services.AddScoped<IAssentoRepository, AssentoRepository>();
            services.AddScoped<IAeronaveRepository, AeronaveRepository>();

            services.AddScoped<ICategoriaFuncionarioRepository, CategoriaFuncionarioRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<ITipoDeVooRepository, TipoDeVooRepository>();
            services.AddScoped<IVooRepository, VooRepository>();

            services.AddIdentity<AppUser, AppRole>()
                .AddRoles<AppRole>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddRoleValidator<RoleValidator<AppRole>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options => 
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            });

            return services;
        }
    }
}
