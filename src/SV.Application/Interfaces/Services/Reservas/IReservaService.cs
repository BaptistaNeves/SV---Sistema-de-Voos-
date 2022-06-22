using SV.Application.InputModels.Reservas;
using SV.Core.DTOs.Reservas;
using SV.Core.Entities.Reservas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Interfaces.Services.Reservas
{
    public interface IReservaService : IDisposable
    {
        Task Inserir(ReservaInputModel reservaModel);
        Task Atualizar(ReservaInputModel reservaModel);
        Task Remover(Guid id);
        Task<Reserva> ObterReservaPorId(Guid id);
        Task<IEnumerable<Reserva>> ObterTodasReservas();
        Task<ReservaDto> ObterReservaDetalhesPorId(Guid id);
        Task<IEnumerable<ReservaDto>> ObterReservasDetalhes();
    }
}
