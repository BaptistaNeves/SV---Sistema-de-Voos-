using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SV.Application.Interfaces.Services.Reservas;
using SV.Core.Interfaces.Notifications;
using SV.UI.Base;
using System;
using System.Threading.Tasks;

namespace SV.UI.Admin.Dashboard.Controllers.Reservas
{
    [Area("Dashboard")]
    [Authorize(Roles = "Operador,Admin")]
    public class ReservaAdminController : MainController
    {
        private readonly IReservaService _reservaService;
        public ReservaAdminController(INotifier notifier, 
                                      IReservaService reservaService) : base(notifier)
        {
            _reservaService = reservaService;
        }

        [HttpGet("admin/reservas")]
        public async Task<IActionResult> Index()
        {
            
            return View(await _reservaService.ObterReservasDetalhes());
        }

        [Route("admin/excluir-reserva/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var reserva = await _reservaService.ObterReservaPorId(id);

            if (reserva == null)
            {
                return NotFound();
            }

            await _reservaService.Remover(id);

            if (!OperacaoIsValide()) return View();

            TempData["success"] = "Reserva excluida com sucesso!";

            return RedirectToAction(nameof(Index));
        }
    }
}
