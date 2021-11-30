using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Saude;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Saude
{
    public class ProdutoTipoFichaValidator : AbstractValidator<ProdutoTipoFicha>
    {
        public ProdutoTipoFichaValidator()
       {

            RuleFor(e => e.ProdutoId)
                .IsRequired();

            RuleFor(e => e.ServicoId)
                .IsRequired();

            RuleFor(e => e.TipoFichaId)
                .IsRequired(); 
        }

    }
}
