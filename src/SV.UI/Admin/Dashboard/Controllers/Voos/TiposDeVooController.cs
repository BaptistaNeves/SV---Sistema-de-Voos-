using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SV.Application.InputModels.Voos;
using SV.Application.Interfaces.Services.Voos;
using SV.Core.Interfaces.Notifications;
using SV.UI.Base;
using System;
using System.Threading.Tasks;

namespace SV.UI.Admin.Dashboard.Controllers.Voos
{
    [Area("Dashboard")]
    [Authorize(Roles = "Operador,Admin")]
    public class TiposDeVooController : MainController
    {
        private readonly ITipoDeVooService _tipoDeVooService;
        public TiposDeVooController(INotifier notifier, 
                                     ITipoDeVooService tipoDeVooService) : base(notifier)
        {
            _tipoDeVooService = tipoDeVooService;
        }


        [HttpGet]
        [Route("admin/tipos-de-voo")]
        public async Task<IActionResult> Index()
        {
            return View(await _tipoDeVooService.ObterTodosTiposDeVoo());
        }

        [HttpGet]
        [Route("admin/novo-tipo-de-voo")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("admin/novo-tipo-de-voo")]
        public async Task<IActionResult> Create(TipoDeVooInputModel tipoDeVooModel)
        {
            if (!ModelState.IsValid) return View(tipoDeVooModel);

            await _tipoDeVooService.Inserir(tipoDeVooModel);

            if (!OperacaoIsValide()) return View(tipoDeVooModel); ;

            TempData["success"] = "Tipo de voo cadastrado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/editar-tipo-de-voo/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tipoDeVoo = await _tipoDeVooService.ObterTipoDeVooPorId(id);

            if (tipoDeVoo == null)
            {
                return NotFound();
            }

            return View(tipoDeVoo);
        }


        [HttpPost]
        [Route("admin/editar-tipo-de-voo/{id:guid}")]
        public async Task<IActionResult> Edit(TipoDeVooInputModel tipoDeVooModel)
        {
            if (!ModelState.IsValid) return View(tipoDeVooModel);

            await _tipoDeVooService.Atualizar(tipoDeVooModel);

            if (!OperacaoIsValide()) return View(tipoDeVooModel);

            TempData["success"] = "Tipo de voo atualizado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/excluir-tipo-de-voo/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var tipoDeVoo = await _tipoDeVooService.ObterTipoDeVooPorId(id);

            if (tipoDeVoo == null)
            {
                return NotFound();
            }

            await _tipoDeVooService.Remover(id);

            if (!OperacaoIsValide()) return View();

            TempData["success"] = "Tipo de voo excluido com sucesso!";

            return RedirectToAction(nameof(Index));
        }
    }
}
