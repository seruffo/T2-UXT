using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.SRC
{
    public class RegiaoUnidadeNegocioValidator : AbstractValidator<RegiaoUnidadeNegocio>
    {
       public RegiaoUnidadeNegocioValidator()
       {
            RuleFor(e => e.RegiaoId).NotNull();
            RuleFor(e => e.TipoRegiaoId).NotNull();
            RuleFor(e => e.UnidadeNegocioId).NotNull();
        }

    }
}
