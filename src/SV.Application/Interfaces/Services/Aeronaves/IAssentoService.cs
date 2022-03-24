using SV.Application.InputModels.Aeronaves;
using SV.Core.Entities.Aeronaves;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Interfaces.Services.Aeronaves
{
    public interface IAssentoService : IDisposable
    {
        Task Inserir(AssentoInputModel inputModel);
        Task Atualizar(AssentoInputModel inputModel);
        Task<AssentoInputModel> ObterAssetoPorId(Guid id);
        Task<IEnumerable<Assento>> ObterTodosAssentos();
        Task Remover(Guid id);
    }
}
