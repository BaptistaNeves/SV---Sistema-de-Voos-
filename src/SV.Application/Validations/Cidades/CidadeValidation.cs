using FluentValidation;
using SV.Application.InputModels.Cidades;

namespace SV.Application.Validations.Cidades
{
    public class CidadeValidation : AbstractValidator<CidadeInputModel>
    {
        public CidadeValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome da Cidade deve ser informado!");

            RuleFor(c => c.Pais)
                .NotEmpty().WithMessage("Informe de qual país esta Cidade pertence!");

        }
    }
}
