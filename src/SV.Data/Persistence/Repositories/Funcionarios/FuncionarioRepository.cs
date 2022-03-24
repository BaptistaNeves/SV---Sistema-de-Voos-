using SV.Core.Entities.Funcionarios;
using SV.Core.Interfaces.Repositories.Funcionarios;
using SV.Data.Persistence.Context;
using SV.Data.Persistence.Repositories.Generic;

namespace SV.Data.Persistence.Repositories.Funcionarios
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
