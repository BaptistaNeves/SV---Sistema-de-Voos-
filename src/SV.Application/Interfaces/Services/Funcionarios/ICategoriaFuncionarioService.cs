using SV.Application.InputModels.Funcionarios;
using SV.Core.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Interfaces.Services.Funcionarios
{
    public interface ICategoriaFuncionarioService : IDisposable
    {
        Task<CategoriaFuncionarioInputModel> ObterCategoriaFuncionarioPorId(Guid id);
        Task<IEnumerable<CategoriaFuncionario>> ObterTodasCategoriasFuncionarios();
        Task Inserir(CategoriaFuncionarioInputModel categoriaModel);
        Task Atualizar(CategoriaFuncionarioInputModel categoriaModel);
        Task Remover(Guid id);
    }
}
