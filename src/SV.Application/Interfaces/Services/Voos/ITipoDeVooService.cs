using SV.Application.InputModels.Voos;
using SV.Core.Entities.Voos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Interfaces.Services.Voos
{
    public  interface ITipoDeVooService : IDisposable
    {
        Task<TipoDeVooInputModel> ObterTipoDeVooPorId(Guid id);
        Task<IEnumerable<TipoDeVoo>> ObterTodosTiposDeVoo();
        Task Inserir(TipoDeVooInputModel cidadeModel);
        Task Atualizar(TipoDeVooInputModel cidadeModel);
        Task Remover(Guid id);
    }
}
