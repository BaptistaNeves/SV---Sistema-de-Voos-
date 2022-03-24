using SV.Application.InputModels.Funcionarios;
using SV.Core.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Interfaces.Services.Funcionarios
{
    public interface IFuncionarioService : IDisposable
    {
        Task<FuncionarioInputModel> ObterFuncionarioPorId(Guid id);
        Task<IEnumerable<Funcionario>> ObterTodosFuncionarios();
        Task Inserir(FuncionarioInputModel funcionarioModel);
        Task Atualizar(FuncionarioInputModel funcionarioModel);
        Task Remover(Guid id);
    }
}
