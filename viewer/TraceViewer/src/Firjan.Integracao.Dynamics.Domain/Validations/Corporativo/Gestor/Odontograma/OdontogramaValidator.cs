using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class OdontogramaValidator : AbstractValidator<Odontograma>
    {
       public OdontogramaValidator()
       {
            RuleFor(e => e.NumeroDente)
                .NotNullNotEmpty();

            RuleFor(e => e.Operacao)
                .NotNullNotEmpty();

            RuleFor(e => e.PessoaId)
                .NotNullNotEmpty();

            RuleFor(e => e.FiguraOdontogramaId)
                .NotNullNotEmpty();
        }
    }
}
