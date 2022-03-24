using SV.Application.InputModels.Cidades;
using SV.Core.ViewModels.Cidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Interfaces.Services.Cidades
{
    public interface ICidadeService : IDisposable
    {
        Task<CidadeViewModel> ObterCidadePorId(Guid id);
        Task<IEnumerable<CidadeViewModel>> ObterTodasCidades();
        Task Inserir(CidadeInputModel cidadeModel);
        Task Atualizar(CidadeInputModel cidadeModel);
        Task Remover(Guid id);
    }
}
