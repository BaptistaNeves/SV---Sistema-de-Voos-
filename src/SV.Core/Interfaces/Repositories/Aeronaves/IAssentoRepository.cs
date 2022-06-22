using SV.Core.Entities.Aeronaves;
using SV.Core.Interfaces.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Core.Interfaces.Repositories.Aeronaves
{
    public interface IAssentoRepository : IRepository<Assento>
    {
        Task<IEnumerable<Assento>> ObterAssentosExecutivosPorVooId(Guid id);
        Task<IEnumerable<Assento>> ObterAssentosEconomicosPorVooId(Guid id);
    }
}
