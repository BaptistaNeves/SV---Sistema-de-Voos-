using FluentValidation;
using SV.Application.InputModels.Aeronaves;

namespace SV.Application.Validations.Aeronaves
{
    public class AeronaveValidation : AbstractValidator<AeronaveInputModel>
    {
        public AeronaveValidation()
        {
            RuleFor(a => a.Modelo)
                .NotEmpty().WithMessage("Informe o Modelo da Aeronave!");

            RuleFor(a => a.Fabricante)
                .NotEmpty().WithMessage("Informe o Fabricante da Aeronave!");

            RuleFor(a => a.TotalDeAssentos)
               .NotEmpty().WithMessage("Informe o Número total de assentos desta Aeronave!")
               .GreaterThan(0).WithMessage("O Número de total de assentos deve ser maior que zero!");
        }
    }
}
