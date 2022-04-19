using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SV.Application.InputModels.Aeroportos;
using SV.Application.Interfaces.Services.Aeroportos;
using SV.Application.Interfaces.Services.Cidades;
using SV.Core.Interfaces.Notifications;
using SV.UI.Admin.Dashboard.ViewModels.Aeroportos;
using SV.UI.Base;
using System;
using System.Threading.Tasks;

namespace SV.UI.Admin.Dashboard.Controllers.Aeronaves
{
    [Area("Dashboard")]
    [Authorize(Roles = "Operador,Admin")]
    public class AeroportosController : MainController
    {
        private readonly IAeroportoService _aeroportoService;
        private readonly ICidadeService _cidadeService;
        public AeroportosController(INotifier notifier,
                                    IAeroportoService aeroportoService, 
                                    ICidadeService cidadeService) : base(notifier)
        {
            _aeroportoService = aeroportoService;
            _cidadeService = cidadeService;
        }

        [HttpGet]
        [Route("admin/aeroportos")]
        public async Task<IActionResult> Index()
        {
            return View(await _aeroportoService.ObterTodosAeroportos());
        }

        [HttpGet]
        [Route("admin/novo-aeroporto")]
        public async Task<IActionResult> Create()
        {
            return View(new AeroportoViewModel { 
                Cidades = await _cidadeService.ObterTodasCidades()
            });
        }

        [HttpPost]
        [Route("admin/novo-aeroporto")]
        public async Task<IActionResult> Create(AeroportoInputModel aeroportoModel)
        {
            if (!ModelState.IsValid) return View(aeroportoModel);

            await _aeroportoService.Inserir(aeroportoModel);

            if (!OperacaoIsValide()) return View(aeroportoModel); ;

            TempData["success"] = "Aeroporto cadastrado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/editar-aeroporto/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var aeroporto = await _aeroportoService.ObterAeroportoPorId(id);

            if (aeroporto == null)
            {
                return NotFound();
            }

            return View(new AeroportoViewModel
            {
                AeroportoModel = aeroporto,
                Cidades = await _cidadeService.ObterTodasCidades()
            });
        }


        [HttpPost, ActionName("Edit")]
        [Route("admin/editar-aeroporto/{id:guid}")]
        public async Task<IActionResult> EditPost(Guid id, AeroportoInputModel aeroportoModel)
        {
            if (!ModelState.IsValid) return View(aeroportoModel);

            await _aeroportoService.Atualizar(aeroportoModel);

            if (!OperacaoIsValide()) return View(aeroportoModel);

            TempData["success"] = "Aeroporto atualizado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/excluir-aeroporto/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var aeroporto = await _aeroportoService.ObterAeroportoPorId(id);

            if (aeroporto == null)
            {
                return NotFound();
            }

            await _aeroportoService.Remover(id);

            if (!OperacaoIsValide()) return View();

            TempData["success"] = "Aeroporto excluido com sucesso!";

            return RedirectToAction(nameof(Index));
        }

    }
}
