using FluentValidation;
using SV.Application.InputModels.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV.Application.Validations.Funcionarios
{
    public class FuncionarioValidation : AbstractValidator<FuncionarioInputModel>
    {
        public FuncionarioValidation()
        {
            
        }
    }
}
