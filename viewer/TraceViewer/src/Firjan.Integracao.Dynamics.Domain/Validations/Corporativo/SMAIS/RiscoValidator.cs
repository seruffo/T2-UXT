using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.SMAIS;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.SMAIS
{
    public class RiscoValidator : AbstractValidator<Risco>
    {
        public RiscoValidator()
        {
            RuleFor(x => x.COD)
               .NotNullNotEmpty();

            RuleFor(x => x.NOME)
              .NotNullNotEmpty();
        }
    }
}