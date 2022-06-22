using Microsoft.EntityFrameworkCore;
using SV.Core.DTOs.Reservas;
using SV.Core.Entities.Reservas;
using SV.Core.Interfaces.Repositories.Reservas;
using SV.Data.Persistence.Context;
using SV.Data.Persistence.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SV.Data.Persistence.Repositories.Reservas
{
    public class ReservaRepository : Repository<Reserva>, IReservaRepository
    {
        private readonly ApplicationDbContext _context;
        public ReservaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ReservaDto> ObterReservaDetalhesPorId(Guid id)
        {
            return await _context.Reservas.AsNoTracking()
                        .Include(x=>x.Voo)
                       .Select(reserva => new ReservaDto
                       {
                           Id = reserva.Id,
                           Voo = reserva.Voo.Descricao,
                           Assento = _context.Assentos.FirstOrDefault(x=>x.Id==reserva.AssentoId).Numero.ToString(),
                           Preco = reserva.Preco,
                           Nome = reserva.Nome,
                           TipoDocumento = reserva.TipoDocumento,
                           NumeroDocumento = reserva.NumeroDocumento,
                           Email = reserva.Email,
                           Telefone = reserva.Telefone,
                           Endereco = reserva.Endereco,
                           Sexo = reserva.Sexo,
                           DataNascimento = reserva.DataNascimento
                       }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ReservaDto>> ObterReservasDetalhes()
        {
            return await _context.Reservas.AsNoTracking()
                        .Include(x => x.Voo)
                       .Select(reserva => new ReservaDto
                       {
                           Id = reserva.Id,
                           Voo = reserva.Voo.Descricao,
                           Assento = _context.Assentos.FirstOrDefault(x => x.Id == reserva.AssentoId).Numero.ToString(),
                           Preco = reserva.Preco,
                           Nome = reserva.Nome,
                           TipoDocumento = reserva.TipoDocumento,
                           NumeroDocumento = reserva.NumeroDocumento,
                           Email = reserva.Email,
                           Telefone = reserva.Telefone,
                           Endereco = reserva.Endereco,
                           Sexo = reserva.Sexo,
                           DataNascimento = reserva.DataNascimento
                       }).ToListAsync();
        }
    }
}
