using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.SRC
{
    public class RegiaoValidator : AbstractValidator<Regiao>
    {
       public RegiaoValidator()
       {
            RuleFor(e => e.Descricao)
                .NotNullNotEmpty()
                .Greater(100);

            RuleFor(e => e.TipoRegiaoId)
                .NotNullNotEmpty();
        }

    }
}
