using FluentValidation;
using SV.Application.InputModels.Usuarios;

namespace SV.Application.Validations.Usuarios
{
    public class UsuarioValidation : AbstractValidator<UsuarioInputModel>
    {
        public UsuarioValidation()
        {
            RuleFor(u => u.NomeDeUtilizador)
                .NotEmpty().WithMessage("O Nome do Úsuario deve ser informado!");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O Email do Úsuario deve ser informado!")
                .EmailAddress().WithMessage("O email é Inválido!");

            RuleFor(u => u.Telefone)
                 .NotEmpty().WithMessage("O Telefone do Úsuario deve ser informado!");

            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("A senha deve ser informado")
                .MinimumLength(6).WithMessage("A senha deve ter no minímo 6 caracteres");
        }
    }
}
