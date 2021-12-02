using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.SRC
{
    public class TipoRegiaoValidator : AbstractValidator<TipoRegiao>
    {
       public TipoRegiaoValidator()
       {
            RuleFor(x => x.Descricao)
                .NotNullNotEmpty()
                .Greater(25);
        }
    }
}
