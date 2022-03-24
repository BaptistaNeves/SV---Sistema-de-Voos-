using FluentValidation;
using SV.Application.InputModels.Aeronaves;

namespace SV.Application.Validations.Aeronaves
{
    public class ClasseValidation : AbstractValidator<ClasseInputModel>
    {
        public ClasseValidation()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Informe o Nome/Descrição da Classe!");
        }
    }
}
