using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class TipoUnidadeNegocioValidator : AbstractValidator<TipoUnidadeNegocio>
    {
       public TipoUnidadeNegocioValidator()
       {
            RuleFor(e => e.Id)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");

            RuleFor(e => e.UnidadeVinculada)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");

            RuleFor(e => e.Id)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");
        }

    }
}
