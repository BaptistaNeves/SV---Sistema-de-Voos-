using SV.Core.Entities.Aeroportos;
using SV.Core.Interfaces.Repositories.Aeroportos;
using SV.Data.Persistence.Context;
using SV.Data.Persistence.Repositories.Generic;

namespace SV.Data.Persistence.Repositories.Aeroportos
{
    public class AeroportoRepository : Repository<Aeroporto>, IAeroportoRepository
    {
        public AeroportoRepository(ApplicationDbContext db) : base(db) {}
    }
}
