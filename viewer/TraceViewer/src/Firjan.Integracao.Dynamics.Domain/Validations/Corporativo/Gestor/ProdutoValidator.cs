using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
       public ProdutoValidator()
       {
            RuleFor(e => e.NivelServicoId)
                .NotNullNotEmpty();

            RuleFor(e => e.TabelaServicoId)
                .NotNullNotEmpty();

            RuleFor(e => e.Inicio)
                .NotNullNotEmpty();

            RuleFor(e => e.Divulgado)
                .NotNullNotEmpty();

            RuleFor(e => e.DivulgadoSite)
                .NotNullNotEmpty();

            RuleFor(e => e.TipoEntidadeVinculoId)
                  .NotNullNotEmpty();

            RuleFor(e => e.Especialidade)
                .NotNullNotEmpty();

            RuleFor(e => e.Validade)
                .NotNullNotEmpty();

            RuleFor(e => e.Atendimento)
                .NotNullNotEmpty();

            RuleFor(e => e.AreaId)
                .NotNullNotEmpty();
        }
    }
}
