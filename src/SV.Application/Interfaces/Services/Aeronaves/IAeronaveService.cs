using SV.Application.InputModels.Aeronaves;
using SV.Core.Entities.Aeronaves;
using SV.Core.ViewModels.Utility;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Interfaces.Services.Aeronaves
{
    public interface IAeronaveService : IDisposable
    {
        Task Inserir(AeronaveInputModel inputModel);
        Task Atualizar(AeronaveInputModel inputModel);
        Task<AeronaveInputModel> ObterAeronavePorId(Guid id);
        Task<IEnumerable<Aeronave>> ObterTodasAeronaves();
        Task Remover(Guid id);
    }
}
