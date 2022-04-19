using FluentValidation;
using SV.Application.InputModels.Usuarios;

namespace SV.Application.Validations.Usuarios
{
    public class UpdateUsuarioValidation : AbstractValidator<UsuarioInputModel>
    {
        public UpdateUsuarioValidation()
        {
            RuleFor(u => u.NomeDeUtilizador)
                .NotEmpty().WithMessage("O Nome do Úsuario deve ser informado!");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O Email do Úsuario deve ser informado!")
                .EmailAddress().WithMessage("O email é Inválido!");

            RuleFor(u => u.Telefone)
                 .NotEmpty().WithMessage("O Telefone do Úsuario deve ser informado!");

            When(u => u.AlterarSenha, ()=> {
                RuleFor(u => u.SenhaAntiga)
                .NotEmpty().WithMessage("A senha antiga deve ser informada!");
            });

            When(u => !string.IsNullOrEmpty(u.SenhaAntiga), () => {
                RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("Informe a senha nova!")
                .MinimumLength(6).WithMessage("A senha deve ter no minímo 6 caracteres");
            });

        }
    }
}
