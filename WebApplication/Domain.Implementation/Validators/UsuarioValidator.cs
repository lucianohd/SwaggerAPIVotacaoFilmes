using Domain.Specs.ValueObjects;
using FluentValidation;
using FluentValidation.Validators;

namespace Domain.Implementation.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .WithErrorCode("01")
                .WithMessage(string.Format(Mensagens.Mensagens.MSG001, "Login"))
                .MaximumLength(30)
                .WithMessage("02")
                .WithMessage(string.Format(Mensagens.Mensagens.MSG002, "Login", "30"));
            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithErrorCode("01")
                .WithMessage(string.Format(Mensagens.Mensagens.MSG001, "Login"))
                .MaximumLength(30)
                .WithMessage("02")
                .WithMessage(string.Format(Mensagens.Mensagens.MSG002, "Login", "30"));
        }
    }
}