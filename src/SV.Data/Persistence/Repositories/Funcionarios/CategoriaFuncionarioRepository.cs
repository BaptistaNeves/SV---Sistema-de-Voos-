using SV.Core.Entities.Funcionarios;
using SV.Core.Interfaces.Repositories.Funcionarios;
using SV.Data.Persistence.Context;
using SV.Data.Persistence.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV.Data.Persistence.Repositories.Funcionarios
{
    public class CategoriaFuncionarioRepository : Repository<CategoriaFuncionario>, ICategoriaFuncionarioRepository
    {
        public CategoriaFuncionarioRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
