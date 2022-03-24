using Microsoft.EntityFrameworkCore;
using SV.Core.Entities.Aeronaves;
using SV.Core.Interfaces.Repositories.Aeronaves;
using SV.Data.Persistence.Context;
using SV.Data.Persistence.Repositories.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SV.Data.Persistence.Repositories.Aeronaves
{
    public class AssentoRepository : Repository<Assento>, IAssentoRepository
    {
        public AssentoRepository(ApplicationDbContext db) : base(db){}
    }
}
