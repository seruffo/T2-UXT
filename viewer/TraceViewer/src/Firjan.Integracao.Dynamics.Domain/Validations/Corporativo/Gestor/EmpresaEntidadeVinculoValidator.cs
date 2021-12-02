using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class EmpresaEntidadeVinculoValidator : AbstractValidator<EmpresaEntidadeVinculo>
    {
       public EmpresaEntidadeVinculoValidator()
       {
            RuleFor(e => e.EmpresaId)
             .Greater(1);

            RuleFor(e => e.TipoEntidadeVinculoId)
            .Greater(2);
        }

    }
}
