using FluentValidation;
using FluentValidation.Results;
using SV.Core.Entities.Base;
using SV.Core.Interfaces.Notifications;
using SV.Core.Notifications;

namespace SV.Application.Services.Base
{
    public abstract class BaseService
    {
        private readonly INotifier _notifier;
        public BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }
        public void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        public void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        public bool IsValide<TV, TE>(TV validator, TE entity) where TV : AbstractValidator<TE> where TE : class
        {
            var ValidationResult = validator.Validate(entity);

            if (ValidationResult.IsValid) return true;

            Notify(ValidationResult);
            return false;
        }
    }
}
