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
    public class ClassesController : MainController
    {
        private readonly IClasseService _classeService;
        public ClassesController(INotifier notifier, 
                                IClasseService classeService) : base(notifier)
        {
            _classeService = classeService;
        }

        [HttpGet]
        [Route("admin/classes")]
        public async Task<IActionResult> Index()
        {
            return View(await _classeService.ObterTodasClasses());
        }

        [HttpGet]
        [Route("admin/nova-classe")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("admin/nova-classe")]
        public async Task<IActionResult> Create(ClasseInputModel classeModel)
        {
            if (!ModelState.IsValid) return View(classeModel);

            await _classeService.Inserir(classeModel);

            if (!OperacaoIsValide()) return View(classeModel); ;

            TempData["success"] = "Classe cadastrada com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/editar-classe/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var classe = await _classeService.ObterClassePorId(id);

            if (classe == null)
            {
                return NotFound();
            }

            return View(classe);
        }


        [HttpPost, ActionName("Edit")]
        [Route("admin/editar-classe/{id:guid}")]
        public async Task<IActionResult> EditPost(Guid id, ClasseInputModel classeModel)
        {
            if (!ModelState.IsValid) return View(classeModel);

            await _classeService.Atualizar(classeModel);

            if (!OperacaoIsValide()) return View(classeModel);

            TempData["success"] = "Classe atualizada com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/excluir-classe/{id:guid}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var classe = await _classeService.ObterClassePorId(id);

            if (classe == null)
            {
                return NotFound();
            }

            await _classeService.Remover(id);

            if (!OperacaoIsValide()) return View();

            TempData["success"] = "Classe excluida com sucesso!";

            return RedirectToAction(nameof(Index));
        }

    }
}
