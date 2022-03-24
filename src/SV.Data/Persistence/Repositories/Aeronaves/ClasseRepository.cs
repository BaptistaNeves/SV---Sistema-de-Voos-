using Microsoft.EntityFrameworkCore;
using SV.Core.Entities.Aeronaves;
using SV.Core.Interfaces.Repositories.Aeronaves;
using SV.Core.ViewModels.Utility;
using SV.Data.Persistence.Context;
using SV.Data.Persistence.Repositories.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SV.Data.Persistence.Repositories.Aeronaves
{
    public class ClasseRepository : Repository<Classe>, IClasseRepository
    {
        public ClasseRepository(ApplicationDbContext db) : base(db){ }
    }
}
