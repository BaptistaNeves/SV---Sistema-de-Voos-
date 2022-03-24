using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SV.Core.Interfaces.Notifications;
using SV.Core.Notifications;
using System.Linq;

namespace SV.UI.Base
{
    public abstract class MainController : Controller
    {
        private readonly INotifier _notifier;
        public MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        [NonAction]
        protected bool OperacaoIsValide()
        {
            return !_notifier.HasNotifications();
        }

            
        [NonAction]
        protected void NotifyErrorModelState(ModelStateDictionary modelSate)
        {
            var erros = modelSate.Values.SelectMany(m => m.Errors);

            foreach (var error in erros)
            {
                NotifyError(error.ErrorMessage);
            }
        }

        [NonAction]
        protected void NotifyError(string message)
        {
            _notifier.Handle(new Notification(message));
        }

    }
}
