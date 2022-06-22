using SV.Core.DTOs.Funcionarios;
using SV.Core.Entities.Funcionarios;
using SV.Core.Interfaces.Repositories.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Core.Interfaces.Repositories.Funcionarios
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        Task<IEnumerable<FuncionarioPilotoECopilotoDto>> ObterFuncionariosPiloto();
        Task<IEnumerable<FuncionarioPilotoECopilotoDto>> ObterFuncionariosCoPiloto();
    }
}
