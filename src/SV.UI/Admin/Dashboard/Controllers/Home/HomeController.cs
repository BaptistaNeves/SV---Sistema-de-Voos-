using Microsoft.AspNetCore.Mvc;
using SV.Core.Interfaces.Notifications;
using SV.UI.Base;

namespace SV.UI.Admin.Dashboard.Controllers.Home
{
    [Area("Dashboard")]
    [Route("admin/inicio")]
    public class HomeController : MainController
    {
        public HomeController(INotifier notifier) : base(notifier){ }

        public IActionResult Index()
        {
            return View();
        }
    }
}
