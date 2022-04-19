using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SV.Application.InputModels.Usuarios;
using SV.Application.Interfaces.Services.Usuarios;
using SV.Core.Interfaces.Notifications;
using SV.UI.Base;
using System;
using System.Threading.Tasks;

namespace SV.UI.Admin.Dashboard.Controllers.Perfil
{
    [Area("Dashboard")]
    [Authorize(Roles = "Operador,Admin")]
    public class PerfilController : MainController
    {
        private readonly IUsuarioService _usuarioService;
        public PerfilController(INotifier notifier, 
                                IUsuarioService usuarioService) : base(notifier)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("admin/editar-perfil/{id:guid}")]
        public async Task<IActionResult> Index(Guid id)
        {
            return View(await _usuarioService.ObterUsuarioPorId(id));
        }

        [HttpPost("admin/editar-perfil/{id:guid}")]
        public async Task<IActionResult> Index(UsuarioInputModel usuarioModel)
        {
            if (!ModelState.IsValid) return View(usuarioModel);

            await _usuarioService.Atualizar(usuarioModel);

            if (!OperacaoIsValide()) return View(usuarioModel);

            TempData["success"] = "Dados atualizado com sucesso!";

            return RedirectToAction(nameof(Index));
        }
    }
}
