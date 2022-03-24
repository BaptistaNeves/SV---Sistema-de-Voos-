using FluentValidation;
using SV.Application.InputModels.Aeroportos;

namespace SV.Application.Validations.Aeroportos
{
    public class AeroportoValidation : AbstractValidator<AeroportoInputModel>
    {
        public AeroportoValidation()
        {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("Informe o Nome do Aeroporto!");


            RuleFor(a => a.CidadeId)
                .NotEmpty().WithMessage("Informe a Cidade do Aeroporto!");
        }
    }
}
