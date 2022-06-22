using AutoMapper;
using SV.Application.InputModels.Reservas;
using SV.Application.Interfaces.Services.Reservas;
using SV.Application.Services.Base;
using SV.Application.Validations.Reservas;
using SV.Core.DTOs.Reservas;
using SV.Core.Entities.Reservas;
using SV.Core.Interfaces.Notifications;
using SV.Core.Interfaces.Repositories.Aeronaves;
using SV.Core.Interfaces.Repositories.Reservas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Services.Reservas
{
    public class ReservaService : BaseService, IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IAssentoRepository _assentoRepository;
        private readonly IMapper _mapper;
        public ReservaService(INotifier notifier,
                              IReservaRepository reservaRepository,
                              IMapper mapper, 
                              IAssentoRepository assentoRepository) : base(notifier)
        {
            _reservaRepository = reservaRepository;
            _mapper = mapper;
            _assentoRepository = assentoRepository;
        }

        public async Task<Reserva> ObterReservaPorId(Guid id)
        {
            return await _reservaRepository.FirstOrDefaultAsync(x => x.Id == id, isTracking: false);
        }

        public async Task<IEnumerable<Reserva>> ObterTodasReservas()
        {
            return await _reservaRepository.GetAllAsync();
        }

        public async Task<ReservaDto> ObterReservaDetalhesPorId(Guid id)
        {
            return await _reservaRepository.ObterReservaDetalhesPorId(id);
        }

        public async Task<IEnumerable<ReservaDto>> ObterReservasDetalhes()
        {
            return await _reservaRepository.ObterReservasDetalhes();
        }

        public async Task Inserir(ReservaInputModel reservaModel)
        {
            if (!IsValide(new ReservaValidation(), reservaModel)) return;

            var reserva = _mapper.Map<Reserva>(reservaModel);

            if (await _reservaRepository.FirstOrDefaultAsync(x => x.Email == reserva.Email) != null)
            {
                Notify("Já existe uma reserva efetuada com este email!");
                return;
            }

            if (await _reservaRepository.FirstOrDefaultAsync(x => x.NumeroDocumento == reserva.NumeroDocumento) != null)
            {
                Notify("Já existe uma reserva efetuada com este número de documento!");
                return;
            }

            _reservaRepository.Add(reserva);
            await _reservaRepository.SaveChangesAsync();

            await AlterarStatusAssento(reserva.AssentoId);
        }
        public async Task Atualizar(ReservaInputModel reservaModel)
        {
            if (!IsValide(new ReservaValidation(), reservaModel)) return;

            var reserva = _mapper.Map<Reserva>(reservaModel);

            if (await _reservaRepository.FirstOrDefaultAsync(x =>
                 x.Email == reservaModel.Email && x.Id != reserva.Id) != null)
            {
                Notify("Já existe uma reserva efetuada com este email!");
                return;
            }

            _reservaRepository.Update(reserva);
            await _reservaRepository.SaveChangesAsync();
        }

        public async Task Remover(Guid id)
        {
            var reserva = await _reservaRepository.FirstOrDefaultAsync(x=> x.Id == id, isTracking: false);
            _reservaRepository.Remove(reserva);

            await _reservaRepository.SaveChangesAsync();

            await ReporStatusAssento(reserva.AssentoId);
        }

        private async Task AlterarStatusAssento(Guid id)
        {
            var assento = await _assentoRepository.FirstOrDefaultAsync(x => x.Id == id, isTracking: false);

            assento.AlterarStatusAssento();

            _assentoRepository.Update(assento);

            await _assentoRepository.SaveChangesAsync();
        }

        private async Task ReporStatusAssento(Guid id)
        {
            var assento = await _assentoRepository.FirstOrDefaultAsync(x => x.Id == id, isTracking: false);

            assento.ReporStatusAssento();

            _assentoRepository.Update(assento);

            await _assentoRepository.SaveChangesAsync();
        }


        public void Dispose()
        {
            _reservaRepository?.Dispose();
            _assentoRepository?.Dispose();
        }
    }
}
