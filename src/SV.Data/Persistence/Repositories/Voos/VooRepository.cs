using Microsoft.EntityFrameworkCore;
using SV.Core.DTOs.Voos;
using SV.Core.Entities.Voos;
using SV.Core.Interfaces.Repositories.Voos;
using SV.Data.Persistence.Context;
using SV.Data.Persistence.Repositories.Generic;
using System;
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
                              Estado = voo.Estado,
                              PrecoCusto = voo.PrecoCusto,
                              Imagem = voo.Imagem
                          }).ToListAsync();
        }

        public async Task<IEnumerable<VooDto>> ObterVoos()
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
                              AeroportoDeOrigem = _context.Aeroportos.AsNoTracking()
                                .Where(a => a.Nome == voo.AeroportoDeOrigem).Include(a => a.Cidade).Select(c => c.Nome).First(),
                              AeroportoDestino = _context.Aeroportos.AsNoTracking()
                                .Where(a => a.Nome == voo.AeroportoDestino).Include(a => a.Cidade).Select(c => c.Nome).First(),
                              DataDePartida = voo.DataDePartida,
                              HoraDePartida = voo.HoraDePartida,
                              PrevisaoDeChegada = voo.PrevisaoDeChegada,
                              PrevisaoDeChegadaAoDestino = voo.PrevisaoDeChegadaAoDestino,
                              Estado = voo.Estado,
                              PrecoCusto = voo.PrecoCusto,
                              Imagem = voo.Imagem
                          }).ToListAsync();
        }

        public async Task<VooDto> ObterVooFiltradoPorId(Guid id)
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
                              AeroportoDeOrigem = _context.Aeroportos.AsNoTracking()
                                .Where(a => a.Nome == voo.AeroportoDeOrigem).Include(a => a.Cidade).Select(c => c.Cidade.Nome).First(),
                              AeroportoDestino = _context.Aeroportos.AsNoTracking()
                                .Where(a => a.Nome == voo.AeroportoDestino).Include(a => a.Cidade).Select(c => c.Cidade.Nome).First(),
                              DataDePartida = voo.DataDePartida.Date,
                              DataIda = voo.DataDePartida.Date.ToShortDateString(),
                              DataRegresso = voo.PrevisaoDeChegada.Date.ToShortDateString(),
                              HoraDePartida = voo.HoraDePartida,
                              PrevisaoDeChegada = voo.PrevisaoDeChegada.Date,
                              PrevisaoDeChegadaAoDestino = voo.PrevisaoDeChegadaAoDestino,
                              Estado = voo.Estado,
                              PrecoCusto = voo.PrecoCusto,
                              Imagem = voo.Imagem
                          }).FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
