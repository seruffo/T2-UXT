using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class TipoEntidadeVinculoValidator : AbstractValidator<TipoEntidadeVinculo>
    {
       public TipoEntidadeVinculoValidator()
       {
            RuleFor(e => e.Descricao)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");
        }

    }
}
