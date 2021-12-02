using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.SRC
{
    public class EntidadeValidator : AbstractValidator<Entidade>
    {
        public EntidadeValidator()
        {
            RuleFor(x => x.Descricao)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");
        }
    }
}