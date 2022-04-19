using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SV.Application.InputModels.Aeronaves;
using SV.Application.Interfaces.Services.Aeronaves;
using SV.Core.Interfaces.Notifications;
using SV.UI.Base;
using System;
using System.Threading.Tasks;

namespace SV.UI.Admin.Dashboard.Controllers.Aeronaves
{
    [Area("Dashboard")]
    [Authorize(Roles = "Operador,Admin")]
    public class AeronavesController : MainController
    {
        private readonly IAeronaveService _aeronaveService;
        public AeronavesController(INotifier notifier,
                                IAeronaveService aeronaveService) : base(notifier)
        {
            _aeronaveService = aeronaveService;
        }

        [HttpGet]
        [Route("admin/aeronaves")]
        public async Task<IActionResult> Index()
        {
            return View(await _aeronaveService.ObterTodasAeronaves());
        }

        [HttpGet]
        [Route("admin/nova-aeronave")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("admin/nova-aeronave")]
        public async Task<IActionResult> Create(AeronaveInputModel aeronaveModel)
        {
            if (!ModelState.IsValid) return View(aeronaveModel);

            await _aeronaveService.Inserir(aeronaveModel);

            if (!OperacaoIsValide()) return View(aeronaveModel); ;

            TempData["success"] = "Aeronave cadastrada com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/editar-aeronave/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var aeronave = await _aeronaveService.ObterAeronavePorId(id);

            if (aeronave == null)
            {
                return NotFound();
            }

            return View(aeronave);
        }


        [HttpPost, ActionName("Edit")]
        [Route("admin/editar-aeronave/{id:guid}")]
        public async Task<IActionResult> EditPost(Guid id, AeronaveInputModel aeronaveModel)
        {
            if (!ModelState.IsValid) return View(aeronaveModel);

            await _aeronaveService.Atualizar(aeronaveModel);

            if (!OperacaoIsValide()) return View(aeronaveModel);

            TempData["success"] = "Aeronave atualizada com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/excluir-aeronave/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var aeronave = await _aeronaveService.ObterAeronavePorId(id);

            if (aeronave == null)
            {
                return NotFound();
            }

            await _aeronaveService.Remover(id);

            if (!OperacaoIsValide()) return View();

            TempData["success"] = "Aeronave excluida com sucesso!";

            return RedirectToAction(nameof(Index));
        }

    }
}
