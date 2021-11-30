using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class ClasssificacaoValidator : AbstractValidator<Classificacao>
    {
       public ClasssificacaoValidator()
       {
            RuleFor(e => e.GrupoClassificacaoId)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");

            RuleFor(e => e.ProdutoId)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");
        }

    }
}
