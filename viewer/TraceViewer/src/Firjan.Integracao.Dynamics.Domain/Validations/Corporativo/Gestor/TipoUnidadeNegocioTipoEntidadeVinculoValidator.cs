using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class TipoUnidadeNegocioTipoEntidadeVinculoValidator : AbstractValidator<TipoUnidadeNegocioTipoEntidadeVinculo>
    {
       public TipoUnidadeNegocioTipoEntidadeVinculoValidator()
       {
            RuleFor(e => e.TipoEntidadeVinculoId)
                .NotNullNotEmpty()
                .Greater(2);

            RuleFor(e => e.TipoUnidadeNegocioId)
                .NotNullNotEmpty()
                .Greater(2);
        }

    }
}
