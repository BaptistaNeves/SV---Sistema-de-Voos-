using Microsoft.AspNetCore.Mvc;
using SV.Application.Interfaces.Services.Aeronaves;
using SV.Application.Interfaces.Services.Voos;
using SV.Core.Interfaces.Notifications;
using SV.UI.Base;
using System;
using System.Threading.Tasks;

namespace SV.UI.Controllers
{
    public class HomeController : MainController
    {
        private readonly IVooService _vooService;
        private readonly IClasseService _classeService;

        public HomeController(INotifier notifier, IVooService vooService, 
                              IClasseService classeService) : base(notifier)
        {
            _vooService = vooService;
            _classeService = classeService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _vooService.ObterVoosParaVitrine());
        }

        [HttpGet]
        [Route("fazer-reserva/{id:guid}")]
        public async Task<IActionResult> ReservaModal(Guid id)
        {
            var voo = await _vooService.ObterVooFiltradoPorId(id);

            return PartialView("_ReservaModal", voo);
        }
    }
}
