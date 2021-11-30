using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class FiguraOdontogramaValidator : AbstractValidator<FiguraOdontograma>
    {
       public FiguraOdontogramaValidator()
       {
            RuleFor(e => e.TipoFigura)
                .NotNullNotEmpty();

            RuleFor(e => e.Face1)
                .IsValidFace();

            RuleFor(e => e.Face2)
                .IsValidFace();

            RuleFor(e => e.Face3)
                .IsValidFace();

            RuleFor(e => e.Face4)
                .IsValidFace();

            RuleFor(e => e.Face5)
                .IsValidFace();

            RuleFor(e => e.Raiz1)
                .IsValidRaiz();

            RuleFor(e => e.Raiz2)
                .IsValidRaiz();

            RuleFor(e => e.Raiz3)
                .IsValidRaiz();
        }
    }
}
