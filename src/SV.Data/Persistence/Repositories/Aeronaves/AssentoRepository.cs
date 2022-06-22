using Microsoft.EntityFrameworkCore;
using SV.Core.Entities.Aeronaves;
using SV.Core.Interfaces.Repositories.Aeronaves;
using SV.Data.Persistence.Context;
using SV.Data.Persistence.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SV.Data.Persistence.Repositories.Aeronaves
{
    public class AssentoRepository : Repository<Assento>, IAssentoRepository
    {
        private readonly ApplicationDbContext _context;
        public AssentoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Assento>> ObterAssentosEconomicosPorVooId(Guid id)
        {
            return await _context.Assentos.AsNoTracking()
                                .Where(x => x.Status == false)   
                                .Where(x => x.VooId == id && x.Classe.Descricao == "Economica" || x.Classe.Descricao == "Econômica")
                                .ToListAsync();
        }

        public async Task<IEnumerable<Assento>> ObterAssentosExecutivosPorVooId(Guid id)
        {
            return await _context.Assentos.AsNoTracking()
                                .Where(x => x.Status == false)
                                .Where(x => x.VooId == id && x.Classe.Descricao == "Executiva")
                                .ToListAsync();
        }
    }
}
