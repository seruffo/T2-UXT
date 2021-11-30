using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class ItemContabilProdutoValidator : AbstractValidator<ItemContabilProduto>
    {
       public ItemContabilProdutoValidator()
       {
            RuleFor(e => e.CodigoEmpresa)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");

            RuleFor(e => e.CodigoCentroResponsabilidade)
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
