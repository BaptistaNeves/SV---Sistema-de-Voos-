using Microsoft.AspNetCore.Mvc;
using SV.Application.InputModels.Login;
using SV.Application.Interfaces.Services.Usuarios;
using SV.Core.Interfaces.Notifications;
using SV.UI.Admin.Dashboard.Controllers.Home;
using SV.UI.Base;
using System.Threading.Tasks;

namespace SV.UI.Admin.Dashboard.Controllers.Login
{
    [Area("Dashboard")]
    public class LoginController : MainController
    {
        private readonly IUsuarioService _usuarioService;
        public LoginController(INotifier notifier, 
                               IUsuarioService usuarioService) : base(notifier)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Index(LoginInputModel loginModel, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid) return View(loginModel);

            if (await _usuarioService.Login(loginModel))
            {
                return  RedirectToAction("Index", "Home");
            }

            return View(loginModel);
        }

        [HttpGet("sair")]
        public async Task<IActionResult> Logout()
        {
            await _usuarioService.Logout();

            return RedirectToAction("Index");
        }
    }
}
