using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SV.Core.Interfaces.Repositories.Aeronaves;
using SV.Core.Interfaces.Repositories.Aeroportos;
using SV.Core.Interfaces.Repositories.Cidades;
using SV.Core.Interfaces.Repositories.Funcionarios;
using SV.Data.Persistence.Context;
using SV.Data.Persistence.Repositories.Aeronaves;
using SV.Data.Persistence.Repositories.Aeroportos;
using SV.Data.Persistence.Repositories.Cidades;
using SV.Data.Persistence.Repositories.Funcionarios;

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


            return services;
        }
    }
}
