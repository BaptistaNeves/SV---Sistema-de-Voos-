using Microsoft.AspNetCore.Mvc;
using SV.Application.Interfaces.Services.Cidades;
using SV.Application.InputModels.Cidades;
using SV.Core.Interfaces.Notifications;
using SV.UI.Base;
using System.Threading.Tasks;
using System;

namespace SV.UI.Admin.Dashboard.Controllers.Cidades
{
    [Area("Dashboard")]
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


        [HttpPut]
        [Route("admin/editar-cidade")]
        public async Task<IActionResult> EditPost(CidadeInputModel cidadeModel)
        {
            if (!ModelState.IsValid) return View(cidadeModel);

            await _cidadeService.Atualizar(cidadeModel);

            if (!OperacaoIsValide()) return View(cidadeModel); ;

            TempData["success"] = "Cidade atualizada com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/excluir-cidade/{id:guid}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var cidade = await _cidadeService.ObterCidadePorId(id);

            if (cidade == null)
            {
                return NotFound();
            }

            await _cidadeService.Remover(id);

            if (!OperacaoIsValide()) return View();

            TempData["success"] = "Cidade excluida com sucesso!";

            return RedirectToAction(nameof(Index));
        }
    }
}
