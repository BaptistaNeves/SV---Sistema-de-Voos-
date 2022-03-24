using SV.Application.InputModels.Aeroportos;
using SV.Core.Entities.Aeroportos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Interfaces.Services.Aeroportos
{
    public interface IAeroportoService : IDisposable
    {
        Task Inserir(AeroportoInputModel inputModel);
        Task Atualizar(AeroportoInputModel inputModel);
        Task<AeroportoInputModel> ObterAeroportoPorId(Guid id);
        Task<IEnumerable<Aeroporto>> ObterTodosAeroportos();
        Task Remover(Guid id);
    }
}
