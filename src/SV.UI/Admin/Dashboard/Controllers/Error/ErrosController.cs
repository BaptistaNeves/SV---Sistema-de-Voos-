using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SV.Core.Interfaces.Notifications;
using SV.UI.Base;

namespace SV.UI.Admin.Dashboard.Controllers.Error
{
    [Area("Dashboard")]
    [Authorize(Roles = "Operador,Admin")]
    public class ErrosController : MainController
    {
        public ErrosController(INotifier notifier) : base(notifier)
        {
        }

        [HttpGet("admin/acesso-negado")]
        public IActionResult UnauthorizedPage()
        {
            return View();
        }
    }
}
