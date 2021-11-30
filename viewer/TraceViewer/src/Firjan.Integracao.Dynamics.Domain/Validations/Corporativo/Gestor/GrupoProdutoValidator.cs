using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class GrupoClassificacaoValidator : AbstractValidator<GrupoClassificacao>
    {
       public GrupoClassificacaoValidator()
       {
            RuleFor(e => e.Nome)
                .NotNullNotEmpty();

            RuleFor(e => e.NumeroOrdem)
                .NotNullNotEmpty();

            RuleFor(e => e.CodigoTipoEntidadeVinculo)
                .NotNullNotEmpty();

            RuleFor(e => e.Fim)
                .NotNullNotEmpty();

            RuleFor(e => e.NivelServico)
                .NotNullNotEmpty();

            RuleFor(e => e.IndicadorProduto)
                .NotNullNotEmpty();
        }

    }
}
