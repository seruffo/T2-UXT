using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class SaudeFiguraOdontogramaValidator : AbstractValidator<SaudeFiguraOdontograma>
    {
       public SaudeFiguraOdontogramaValidator()
       {
            RuleFor(e => e.FiguraOdontogramaId)
                .NotNullNotEmpty();

            RuleFor(e => e.SaudeId)
                .NotNullNotEmpty();

        }
    }
}
