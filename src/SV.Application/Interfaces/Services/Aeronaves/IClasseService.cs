using SV.Application.InputModels.Aeronaves;
using SV.Core.Entities.Aeronaves;
using SV.Core.ViewModels.Utility;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Interfaces.Services.Aeronaves
{
    public interface IClasseService : IDisposable
    {
        Task Inserir(ClasseInputModel inputModel);
        Task Atualizar(ClasseInputModel inputModel);
        Task<ClasseInputModel> ObterClassePorId(Guid id);
        Task<IEnumerable<Classe>> ObterTodasClasses();
        Task Remover(Guid id);
    }
}
