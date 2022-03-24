using Microsoft.Extensions.DependencyInjection;
using SV.Application.AutoMapper;
using SV.Application.Interfaces.Services.Aeronaves;
using SV.Application.Interfaces.Services.Aeroportos;
using SV.Application.Interfaces.Services.Cidades;
using SV.Application.Interfaces.Services.Funcionarios;
using SV.Application.Services.Aeronaves;
using SV.Application.Services.Aeroportos;
using SV.Application.Services.Cidades;
using SV.Application.Services.Funcionarios;

namespace SV.Application.Extension
{
    public static class ApplicationDependecyInjection
    {
        public static IServiceCollection AddApplicationDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<IAeroportoService, AeroportoService>();

            services.AddScoped<IClasseService, ClasseService>();
            services.AddScoped<IAeronaveService, AeronaveService>();
            services.AddScoped<IAssentoService, AssentoService>();

            services.AddScoped<ICategoriaFuncionarioService, CategoriaFuncionarioService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();

            services.AddAutoMapper(typeof(InputModelsToEntities));
            services.AddAutoMapper(typeof(EntitiesToViewModels));
            
            return services;
        }
    }
}
