using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class ContaContabilProdutoValidator : AbstractValidator<ContaContabilProduto>
    {
       public ContaContabilProdutoValidator()
       {
            RuleFor(e => e.CodigoEmpresa)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");

            RuleFor(e => e.CodigoConta)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");

            RuleFor(e => e.Inicio)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");

            RuleFor(e => e.ProdutoId)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");
        }

    }
}
