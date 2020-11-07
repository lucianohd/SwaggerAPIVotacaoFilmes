using Domain.Specs.ValueObjects;
using FluentValidation;

namespace Domain.Implementation.Validators
{
    public class FilmeValidator : AbstractValidator<Filme>
    {
        public FilmeValidator()
        {
            RuleFor(x => x.Diretor)
                .MaximumLength(50)
                .WithErrorCode("002")
                .WithMessage(string.Format(Mensagens.Mensagens.MSG002, "Diretor", "50"))
                .NotEmpty()
                .WithErrorCode("001")
                .WithMessage(string.Format(Mensagens.Mensagens.MSG001, "Diretor"));
            RuleFor(x => x.Nome)
                .MaximumLength(100)
                .WithErrorCode("002")
                .WithMessage(string.Format(Mensagens.Mensagens.MSG002, "Nome", "100"))
                .NotEmpty()
                .WithErrorCode("001")
                .WithMessage(string.Format(Mensagens.Mensagens.MSG001, "Nome"));
            RuleFor(x => x.Atores)
                .MaximumLength(50)
                .WithErrorCode("002")
                .WithMessage(string.Format(Mensagens.Mensagens.MSG002, "Atores", "50"))
                .NotEmpty()
                .WithErrorCode("001")
                .WithMessage(string.Format(Mensagens.Mensagens.MSG001, "Atores"));
            RuleFor(x => x.Genero)
                .MaximumLength(15)
                .WithErrorCode("002")
                .WithMessage(string.Format(Mensagens.Mensagens.MSG002, "Genero", "15"))
                .NotEmpty()
                .WithErrorCode("001")
                .WithMessage(string.Format(Mensagens.Mensagens.MSG001, "Genero"));
            
        }
    }
}