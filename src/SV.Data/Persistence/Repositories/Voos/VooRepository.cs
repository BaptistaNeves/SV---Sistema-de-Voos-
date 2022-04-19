using Microsoft.EntityFrameworkCore;
using SV.Core.DTOs.Voos;
using SV.Core.Entities.Voos;
using SV.Core.Interfaces.Repositories.Voos;
using SV.Data.Persistence.Context;
using SV.Data.Persistence.Repositories.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SV.Data.Persistence.Repositories.Voos
{
    public class VooRepository : Repository<Voo>, IVooRepository
    {
        private readonly ApplicationDbContext _context;
        public VooRepository(ApplicationDbContext context = null) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VooDto>> ObterVoosFiltrados()
        {
            return await _context.Voos.AsNoTracking()
                          .Include(v => v.Aeronave)
                          .Include(v => v.TipoDeVoo)
                          .Select(voo => new VooDto
                          {
                              Id = voo.Id,
                              Descricao = voo.Descricao,
                              TipoDeVoo = voo.TipoDeVoo.Nome,
                              Aeronave = voo.Aeronave.Modelo,
                              AeroportoDeOrigem = voo.AeroportoDestino,
                              AeroportoDestino = voo.AeroportoDestino,
                              DataDePartida = voo.DataDePartida,
                              HoraDePartida = voo.HoraDePartida,
                              PrevisaoDeChegada = voo.PrevisaoDeChegada,
                              PrevisaoDeChegadaAoDestino = voo.PrevisaoDeChegadaAoDestino,
                              Estado = voo.Estado
                          }).ToListAsync();
        }
    }
}
