using SV.Core.DTOs.Reservas;
using SV.Core.Entities.Reservas;
using SV.Core.Interfaces.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Core.Interfaces.Repositories.Reservas
{
    public interface IReservaRepository : IRepository<Reserva>
    {
        Task<ReservaDto> ObterReservaDetalhesPorId(Guid id);
        Task<IEnumerable<ReservaDto>> ObterReservasDetalhes();
    }
}
