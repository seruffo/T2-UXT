using FluentValidation;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Saude
{
    public class SaudeValidator : AbstractValidator<Models.Corporativo.Gestor.Saude>
    {
        public SaudeValidator()
       {
            RuleFor(e => e.TipoServicoSaude)
                .NotNullNotEmpty();

            RuleFor(e => e.Produto)
                .IsRequired();

            RuleFor(e => e.ProdutoId)
                .IsRequired();
        }
    }
}
