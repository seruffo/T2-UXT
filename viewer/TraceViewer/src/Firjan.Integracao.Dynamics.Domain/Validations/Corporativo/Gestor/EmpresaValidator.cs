using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class EmpresaValidator : AbstractValidator<Empresa>
    {
       public EmpresaValidator()
       {
          RuleFor(e => e.Descricao)
            .NotNull()
            .WithMessage("{PropertyName} must not be null")
            .Greater(100);
        }
    }
}
