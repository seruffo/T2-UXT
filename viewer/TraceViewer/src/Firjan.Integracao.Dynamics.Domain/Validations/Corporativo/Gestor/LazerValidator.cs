using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class LazerValidator : AbstractValidator<Lazer>
    {
       public LazerValidator()
       {
            RuleFor(e => e.FamiliaLazer)
                .NotNullNotEmpty();

            RuleFor(e => e.Id)
                .NotNullNotEmpty();

            RuleFor(e => e.TipoLazer)
                .NotNullNotEmpty();
        }

    }
}
