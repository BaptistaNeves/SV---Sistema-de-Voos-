using FluentValidation;
using SV.Application.InputModels.Voos;

namespace SV.Application.Validations.Voos
{
    public class TipoDeVooValidation : AbstractValidator<TipoDeVooInputModel>
    {
        public TipoDeVooValidation()
        {
            RuleFor(t => t.Nome)
                .NotEmpty().WithMessage("O nome do tipo de voo deve ser informado!")
                .MinimumLength(5).WithMessage("O nome deve ter no minimo 5 caracteres!");
        }
    }
}
