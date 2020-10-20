using Domain.Specs.ValueObjects;
using FluentValidation;

namespace Domain.Implementation.Validators
{
    public class VotoValidator : AbstractValidator<Voto>
    {
        public VotoValidator()
        {
            RuleFor(x => x.Nota)
                .GreaterThan(4)
                .WithErrorCode("002")
                .WithMessage(string.Format(Mensagens.Mensagens.MSG002, "Nota", "4"))
                .NotEmpty()
                .WithErrorCode("001")
                .WithMessage(string.Format(Mensagens.Mensagens.MSG001, "Nota"));
        }
    }
}