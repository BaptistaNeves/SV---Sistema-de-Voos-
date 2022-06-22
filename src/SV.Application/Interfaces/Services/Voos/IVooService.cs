using SV.Application.InputModels.Voos;
using SV.Core.DTOs.Voos;
using SV.Core.Entities.Voos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Interfaces.Services.Voos
{
    public interface IVooService : IDisposable
    {
        Task<VooInputModel> ObterVooPorId(Guid id);
        Task<VooDto> ObterVooFiltradoPorId(Guid id);
        Task<IEnumerable<Voo>> ObterTodosVoos();
        Task<IEnumerable<VooDto>> ObterVoosParaVitrine();
        Task<IEnumerable<VooDto>> ObterVoosFiltrados();
        Task Inserir(VooInputModel cidadeModel);
        Task Atualizar(VooInputModel cidadeModel);
        Task Remover(Guid id);
    }
}
