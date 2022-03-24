using FluentValidation;
using SV.Application.InputModels.Funcionarios;

namespace SV.Application.Validations.Funcionarios
{
    public class CategoriaFuncionarioValidation : AbstractValidator<CategoriaFuncionarioInputModel>
    {
        public CategoriaFuncionarioValidation()
        {

        }
    }
}
