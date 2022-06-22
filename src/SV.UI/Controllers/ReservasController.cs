using Microsoft.AspNetCore.Mvc;
using SV.Application.Interfaces.Services.Aeronaves;
using SV.Application.Interfaces.Services.Reservas;
using SV.Application.Interfaces.Services.Voos;
using SV.Core.DTOs.Voos;
using SV.Core.Interfaces.Notifications;
using SV.UI.Base;
using SV.UI.ViewModels;
using System;
using System.Threading.Tasks;

namespace SV.UI.Controllers
{
    public class ReservasController : MainController
    {
        private readonly IReservaService _reservaService;
        private readonly IVooService _vooService;
        private readonly IClasseService _classeService;
        private readonly IAssentoService _assentoService;
        public ReservasController(INotifier notifier,
                                  IReservaService reservaService,
                                  IVooService vooService,
                                  IClasseService classeService, 
                                  IAssentoService assentoService) : base(notifier)
        {
            _reservaService = reservaService;
            _vooService = vooService;
            _classeService = classeService;
            _assentoService = assentoService;
        }

        [HttpGet("reserva/{id:guid}")]
        public async Task<IActionResult> Index(Guid id)
        {

            return View(new ReservaViewModel
            {
                Voo = await _vooService.ObterVooFiltradoPorId(id),
                Executiva = await _assentoService.ObterAssentosExecutivosPorVooId(id),
                Economica = await _assentoService.ObterAssentosEconomicosPorVooId(id)
            });
        }

        [HttpPost("reserva/{id:guid}")]
        public async Task<IActionResult> Index(Guid id, ReservaViewModel reservaModel)
        {
            var voo = await _vooService.ObterVooFiltradoPorId(id);
            if (!ModelState.IsValid)
            {
                return View(new ReservaViewModel
                {
                    ReservaInputModel = reservaModel.ReservaInputModel,
                    Voo = await _vooService.ObterVooFiltradoPorId(id),
                    Executiva = await _assentoService.ObterAssentosExecutivosPorVooId(id),
                    Economica = await _assentoService.ObterAssentosEconomicosPorVooId(id)
                });
            }

            reservaModel.ReservaInputModel.VooId = id;
            reservaModel.ReservaInputModel.Preco = voo.PrecoCusto;

            await _reservaService.Inserir(reservaModel.ReservaInputModel);

            if (!OperacaoIsValide())
            {
                return View(new ReservaViewModel
                {
                    ReservaInputModel = reservaModel.ReservaInputModel,
                    Voo = voo,
                    Executiva = await _assentoService.ObterAssentosExecutivosPorVooId(id),
                    Economica = await _assentoService.ObterAssentosEconomicosPorVooId(id)
                });
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
