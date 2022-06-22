using Microsoft.EntityFrameworkCore;
using SV.Core.DTOs.Funcionarios;
using SV.Core.Entities.Funcionarios;
using SV.Core.Interfaces.Repositories.Funcionarios;
using SV.Data.Persistence.Context;
using SV.Data.Persistence.Repositories.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SV.Data.Persistence.Repositories.Funcionarios
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        private readonly ApplicationDbContext _context;
        public FuncionarioRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FuncionarioPilotoECopilotoDto>> ObterFuncionariosCoPiloto()
        {
            return await _context.Funcionarios.AsNoTracking()
                    .Include(f => f.CategoriaFuncionario)
                    .Where(f => f.CategoriaFuncionario.Nome == "Co-piloto")
                    .Select(funcionario => new FuncionarioPilotoECopilotoDto
                    {
                        Nome = funcionario.Nome
                    }).ToListAsync();
        }

        public async Task<IEnumerable<FuncionarioPilotoECopilotoDto>> ObterFuncionariosPiloto()
        {
            return await _context.Funcionarios.AsNoTracking()
                    .Include(f => f.CategoriaFuncionario)
                    .Where(f => f.CategoriaFuncionario.Nome == "Piloto")
                    .Select(funcionario => new FuncionarioPilotoECopilotoDto
                    {
                        Nome = funcionario.Nome
                    }).ToListAsync();
        }
    }
}
