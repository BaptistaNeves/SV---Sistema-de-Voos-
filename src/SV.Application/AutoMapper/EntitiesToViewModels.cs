using AutoMapper;
using SV.Core.Entities.Cidades;
using SV.Core.ViewModels.Cidades;

namespace SV.Application.AutoMapper
{
    public class EntitiesToViewModels : Profile
    {
        public EntitiesToViewModels()
        {
            CreateMap<Cidade, CidadeViewModel>();
        }
    }
}
