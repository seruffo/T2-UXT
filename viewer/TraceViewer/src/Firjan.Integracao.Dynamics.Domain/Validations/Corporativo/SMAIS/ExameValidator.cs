using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.SMAIS;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.SMAIS
{
    public class ExameValidator : AbstractValidator<Exame>
    {
        public ExameValidator()
        {
            RuleFor(x => x.COD)
               .NotNullNotEmpty();

            RuleFor(x => x.DESCRICAO)
              .NotNullNotEmpty();
        }
    }
}