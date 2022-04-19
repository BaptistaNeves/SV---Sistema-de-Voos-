using SV.Core.Entities.Voos;
using SV.Core.Interfaces.Repositories.Voos;
using SV.Data.Persistence.Context;
using SV.Data.Persistence.Repositories.Generic;

namespace SV.Data.Persistence.Repositories.Voos
{
    public class TipoDeVooRepository : Repository<TipoDeVoo>, ITipoDeVooRepository
    {
        public TipoDeVooRepository(ApplicationDbContext db) : base(db) { }
    }
}
