using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Protheus
{
    public class EmpresaValidator : AbstractValidator<Empresa>
    {
       public EmpresaValidator()
       {
          RuleFor(e => e.Id)
            .NotNull()
            .WithMessage("{PropertyName} must not be null");

          RuleFor(e => e.Descricao)
            .NotNull()
            .WithMessage("{PropertyName} must not be null");

          RuleFor(e => e.Descricao)
            .NotNull()
            .WithMessage("{PropertyName} must not be null");
        }

    }
}
