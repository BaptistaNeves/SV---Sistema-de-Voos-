using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SV.Application.InputModels.Usuarios;
using SV.Application.Interfaces.Common;
using SV.Application.Interfaces.Services.Usuarios;
using SV.Core.Interfaces.Notifications;
using SV.UI.Base;
using System;
using System.Threading.Tasks;

namespace SV.UI.Admin.Dashboard.Controllers.Usuarios
{

    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class UsuariosController : MainController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ICurrentUserService _currentUserService;

        public UsuariosController(INotifier notifier,
                                  IUsuarioService usuarioService, 
                                  ICurrentUserService currentUserService) : base(notifier)
        {
            _usuarioService = usuarioService;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        [Route("admin/usuarios")]
        public async Task<IActionResult> Index()
        {
            return View(await _usuarioService.
                ObterTodosUsuariosMenosLogado(Guid.Parse(_currentUserService.UserId)));
        }

        [HttpGet]
        [Route("admin/novo-usuario")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("admin/novo-usuario")]
        public async Task<IActionResult> Create(UsuarioInputModel usuarioModel)
        {
            if (!ModelState.IsValid) return View(usuarioModel);

            await _usuarioService.Inserir(usuarioModel);

            if (!OperacaoIsValide()) return View(usuarioModel); ;

            TempData["success"] = "Úsuario cadastrado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/editar-usuario/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var usuario = await _usuarioService.ObterUsuarioPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }


        [HttpPost]
        [Route("admin/editar-usuario/{id:guid}")]
        public async Task<IActionResult> Edit(UsuarioInputModel usuarioModel)
        {
            if (!ModelState.IsValid) return View(usuarioModel);

            await _usuarioService.Atualizar(usuarioModel);

            if (!OperacaoIsValide()) return View(usuarioModel);

            TempData["success"] = "Úsuario atualizado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/excluir-usuario/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var aeronave = await _usuarioService.ObterUsuarioPorId(id);

            if (aeronave == null)
            {
                return NotFound();
            }

            await _usuarioService.Remove(id);

            if (!OperacaoIsValide()) return View();

            TempData["success"] = "Úsuario excluido com sucesso!";

            return RedirectToAction(nameof(Index));
        }
    }
}
