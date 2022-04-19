using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SV.Application.InputModels.Funcionarios;
using SV.Application.Interfaces.Services.Funcionarios;
using SV.Core.Interfaces.Notifications;
using SV.UI.Admin.Dashboard.ViewModels.Funcionarios;
using SV.UI.Base;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SV.UI.Admin.Dashboard.Controllers.Funcionarios
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class FuncionariosController : MainController
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly ICategoriaFuncionarioService _categoriaService;
        public FuncionariosController(INotifier notifier,
                                      IFuncionarioService funcionarioService, 
                                      ICategoriaFuncionarioService categoriaService) : base(notifier)
        {
            _funcionarioService = funcionarioService;
            _categoriaService = categoriaService;
        }

        [HttpGet]
        [Route("admin/funcionarios")]
        public async Task<IActionResult> Index()
        {
            return View(await _funcionarioService.ObterTodosFuncionarios());
        }

        [HttpGet]
        [Route("admin/novo-funcionario")]
        public async Task<IActionResult> Create()
        {
            return View(new FuncionarioViewModel
            {
                Categorias = await _categoriaService.ObterTodasCategoriasFuncionarios()
            });
        }

        [HttpPost]
        [Route("admin/novo-funcionario")]
        public async Task<IActionResult> Create(FuncionarioInputModel funcionarioModel)
        {
            if (!ModelState.IsValid) 
            { 
                return View(new FuncionarioViewModel
                {
                    Categorias = await _categoriaService.ObterTodasCategoriasFuncionarios(),
                    FuncionarioModel = funcionarioModel
                }); 
            }
           
            var imgPrefixo = Guid.NewGuid() + "_";
            
            funcionarioModel.Imagem = imgPrefixo + Path.GetFileName(funcionarioModel.ImagemUpload.FileName.Trim());

            await _funcionarioService.Inserir(funcionarioModel);

            if (!OperacaoIsValide()) 
            {
                return View(new FuncionarioViewModel
                {
                    Categorias = await _categoriaService.ObterTodasCategoriasFuncionarios(),
                    FuncionarioModel = funcionarioModel
                });
            }

            if (!await UploadImage(funcionarioModel.ImagemUpload, imgPrefixo))
            {
                return View(new FuncionarioViewModel
                {
                    Categorias = await _categoriaService.ObterTodasCategoriasFuncionarios(),
                    FuncionarioModel = funcionarioModel
                });
            }

            TempData["success"] = "Funcionário cadastrado com successo!";
            
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/editar-funcionario/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var funcionario = await _funcionarioService.ObterFuncionarioPorId(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(new FuncionarioViewModel
            {
                Categorias = await _categoriaService.ObterTodasCategoriasFuncionarios(),
                FuncionarioModel = funcionario
            });
        }


        [HttpPost]
        [Route("admin/editar-funcionario/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, FuncionarioInputModel funcionarioModel)
        {
            var funcionario = await _funcionarioService.ObterFuncionarioPorId(id);

            if (funcionario == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(new FuncionarioViewModel
                {
                    Categorias = await _categoriaService.ObterTodasCategoriasFuncionarios(),
                    FuncionarioModel = funcionarioModel
                });
            }

            var imgPrefixo = Guid.NewGuid() + "_";

            var imagemAntiga = funcionario.Imagem;

            funcionarioModel.Imagem = imgPrefixo + Path.GetFileName(funcionarioModel.ImagemUpload.FileName.Trim());

            await _funcionarioService.Atualizar(funcionarioModel);

            if (!OperacaoIsValide())
            {
                return View(new FuncionarioViewModel
                {
                    Categorias = await _categoriaService.ObterTodasCategoriasFuncionarios(),
                    FuncionarioModel = funcionarioModel
                });
            }

            if (funcionarioModel.ImagemUpload != null)
            {
                if (!await UploadImage(funcionarioModel.ImagemUpload, imgPrefixo)) return View(funcionarioModel);

                DeleteUploadedImage(imagemAntiga);
            }

            TempData["success"] = "Funcionário atualizado com successo!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/excluir-funcionario/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var funcionario = await _funcionarioService.ObterFuncionarioPorId(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            await _funcionarioService.Remover(id);

            if (!OperacaoIsValide()) return View();

            DeleteUploadedImage(funcionario.Imagem);

            TempData["success"] = "Funcionário excluido com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public async Task<bool> UploadImage(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadedImages/admin/", imgPrefixo + Path.GetFileName(arquivo.FileName.Trim()));

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }

        [NonAction]
        public void DeleteUploadedImage(string arquivo)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadedImages/admin/", arquivo);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}
