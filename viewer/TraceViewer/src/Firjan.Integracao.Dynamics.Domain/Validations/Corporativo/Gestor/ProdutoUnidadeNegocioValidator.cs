using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class ProdutoUnidadeNegocioValidator : AbstractValidator<ProdutoUnidadeNegocio>
    {
       public ProdutoUnidadeNegocioValidator()
       {
            RuleFor(e => e.Inicio).NotNullNotEmpty();
            RuleFor(e => e.ProdutoId).NotNullNotEmpty();
            RuleFor(e => e.UnidadeNegocioId).NotNullNotEmpty();
            RuleFor(e => e.ExecutaServicoOferecido)
                .NotNullNotEmpty();
                
        }

    }
}
