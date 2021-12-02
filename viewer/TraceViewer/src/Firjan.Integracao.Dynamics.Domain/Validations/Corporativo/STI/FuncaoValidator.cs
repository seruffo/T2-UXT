using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.STI
{
    public class FuncaoValidator : AbstractValidator<Funcao>
    {
        public FuncaoValidator()
        {
            RuleFor(e => e.Nome)
                .NotNull()
                .MaximumLength(50)
                .WithMessage("{PropertyName} must not be null");

            RuleFor(e => e.Codigo)
                .NotNull()
                .MaximumLength(5)
                .WithMessage("{PropertyName} must contain 5 caracters");

            RuleFor(e => e.Sigla)
                .MaximumLength(10)
                .WithMessage("{PropertyName} must contain 10 caracters");

            RuleFor(e => e.ParticipantePF)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");

            RuleFor(e => e.ParticipantePJ)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");
            
            RuleFor(e => e.ValidaFavorecidoContratoPF)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");

            RuleFor(e => e.Inicio)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");

            RuleFor(e => e.Fim)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");
        }

    }
}
