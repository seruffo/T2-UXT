using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class TabelaServicoTipoEntidadeVinculoValidator : AbstractValidator<TabelaServicoTipoEntidadeVinculo>
    {
       public TabelaServicoTipoEntidadeVinculoValidator()
       {
            RuleFor(e => e.Id)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");

            RuleFor(e => e.Descricao)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");

        }

    }
}
