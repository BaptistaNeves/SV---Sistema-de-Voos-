using SV.Core.DTOs.Voos;
using SV.Core.Entities.Voos;
using SV.Core.Interfaces.Repositories.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Core.Interfaces.Repositories.Voos
{
    public interface IVooRepository : IRepository<Voo> 
    {
        Task<IEnumerable<VooDto>> ObterVoosFiltrados();
    }
}
