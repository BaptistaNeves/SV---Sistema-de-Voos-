using SV.Core.Entities.Cidades;
using SV.Core.Interfaces.Repositories.Cidades;
using SV.Data.Persistence.Context;
using SV.Data.Persistence.Repositories.Generic;

namespace SV.Data.Persistence.Repositories.Cidades
{
    public class CidadeRepository : Repository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
