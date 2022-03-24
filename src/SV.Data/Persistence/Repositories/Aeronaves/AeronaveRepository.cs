using SV.Core.Entities.Aeronaves;
using SV.Core.Interfaces.Repositories.Aeronaves;
using SV.Data.Persistence.Context;
using SV.Data.Persistence.Repositories.Generic;

namespace SV.Data.Persistence.Repositories.Aeronaves
{
    public class AeronaveRepository : Repository<Aeronave>, IAeronaveRepository
    {
        public AeronaveRepository(ApplicationDbContext db) : base(db){}
    }
}
