using Microsoft.AspNetCore.Mvc;
using SV.Application.Interfaces.Services.Cidades;
using SV.Application.InputModels.Cidades;
using SV.Core.Interfaces.Notifications;
using SV.UI.Base;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;

namespace SV.UI.Admin.Dashboard.Controllers.Cidades
{
    [Area("Dashboard")]
    [Authorize(Roles = "Operador,Admin")]
    public class CidadesController : MainController
    {
        private readonly ICidadeService _cidadeService;
        public CidadesController(INotifier notifier, 
                                 ICidadeService cidadeService) : base(notifier)
        {
            _cidadeService = cidadeService;
        }

        [Route("admin/cidades")]
        public async Task<IActionResult> Index()
        {
            return View(await _cidadeService.ObterTodasCidades());
        }

        [HttpGet]
        [Route("admin/nova-cidade")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("admin/nova-cidade")]
        public async Task<IActionResult> Create(CidadeInputModel cidadeModel)
        {
            if(!ModelState.IsValid) return View(cidadeModel);

            await _cidadeService.Inserir(cidadeModel);

            if(!OperacaoIsValide()) return View(cidadeModel);

            TempData["success"] = "Cidade cadastrada com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/editar-cidade/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var cidade = await _cidadeService.ObterCidadePorId(id);

            if (cidade == null)
            {
                return NotFound();
            }
            var cidadeModel = new CidadeInputModel
            {
                Nome = cidade.Nome,
                Pais = cidade.Pais,
                Descricao = cidade.Descricao
            };

            return View(cidadeModel);
        }


        [HttpPost]
        [Route("admin/editar-cidade/{id:guid}")]
        public async Task<IActionResult> Edit(CidadeInputModel cidadeModel)
        {
            if (!ModelState.IsValid) return View(cidadeModel);

            await _cidadeService.Atualizar(cidadeModel);

            if (!OperacaoIsValide()) return View(cidadeModel); ;

            TempData["success"] = "Cidade atualizada com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/excluir-cidade/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cidade = await _cidadeService.ObterCidadePorId(id);

            if (cidade == null)
            {
                return NotFound();
            }

            await _cidadeService.Remover(id);

            if (!OperacaoIsValide())
            {
                TempData["warning"] = "Esta cidade possui  aeroportos cadastrados não pode ser excluida!";

                return RedirectToAction(nameof(Index));
            };

            TempData["success"] = "Cidade excluida com sucesso!";

            return RedirectToAction(nameof(Index));
        }
    }
}
