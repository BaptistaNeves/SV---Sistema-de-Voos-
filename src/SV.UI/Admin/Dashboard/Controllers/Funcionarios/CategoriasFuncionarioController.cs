using Microsoft.AspNetCore.Mvc;
using SV.Application.InputModels.Funcionarios;
using SV.Application.Interfaces.Services.Funcionarios;
using SV.Core.Interfaces.Notifications;
using SV.UI.Base;
using System;
using System.Threading.Tasks;

namespace SV.UI.Admin.Dashboard.Controllers.Funcionarios
{
    [Area("Dashboard")]
    public class CategoriasFuncionarioController : MainController
    {
        private readonly ICategoriaFuncionarioService _categoriaFuncionarioService;
        public CategoriasFuncionarioController(INotifier notifier, 
                          ICategoriaFuncionarioService categoriaFuncionarioService) : base(notifier)
        {
            _categoriaFuncionarioService = categoriaFuncionarioService;
        }

        [HttpGet]
        [Route("admin/categorias-funcionario")]
        public async Task<IActionResult> Index()
        {
            return View(await _categoriaFuncionarioService.ObterTodasCategoriasFuncionarios());
        }

        [HttpGet]
        [Route("admin/nova-categoria/funcionario")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("admin/nova-categoria/funcionario")]
        public async Task<IActionResult> Create(CategoriaFuncionarioInputModel categoriaModel)
        {
            if (!ModelState.IsValid) return View(categoriaModel);

            await _categoriaFuncionarioService.Inserir(categoriaModel);

            if (!OperacaoIsValide()) return View(categoriaModel); ;

            TempData["success"] = "Categoria cadastrada com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/editar-categoria-funcionario/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var categoria = await _categoriaFuncionarioService.ObterCategoriaFuncionarioPorId(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }


        [HttpPost, ActionName("Edit")]
        [Route("admin/editar-categoria-funcionario/{id:guid}")]
        public async Task<IActionResult> EditPost(Guid id, CategoriaFuncionarioInputModel categoriaModel)
        {
            if (!ModelState.IsValid) return View(categoriaModel);

            await _categoriaFuncionarioService.Atualizar(categoriaModel);

            if (!OperacaoIsValide()) return View(categoriaModel);

            TempData["success"] = "Categoria atualizada com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/excluir-categoria-funcionario/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var categoria = await _categoriaFuncionarioService.ObterCategoriaFuncionarioPorId(id);

            if (categoria == null)
            {
                return NotFound();
            }

            await _categoriaFuncionarioService.Remover(id);

            if (!OperacaoIsValide()) return View();

            TempData["success"] = "Categoria excluida com sucesso!";

            return RedirectToAction(nameof(Index));
        }
    }
}
