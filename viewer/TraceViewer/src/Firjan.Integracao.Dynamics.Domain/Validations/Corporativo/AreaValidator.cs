using Firjan.Integracao.Dynamics.Domain.Models.STI;
using FluentValidation;

namespace Firjan.Integracao.Dynamics.Domain.Validations.STI
{
    public class AreaValidator : AbstractValidator<Area>
    {
        public AreaValidator()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty()
                .NotNull()
                .WithMessage("A descrição precisa ser preenchida");

            //RuleForEach(c => c.Enderecos).NotNull();

            RuleSet("DescricaoPreenchido", () =>
            {
                RuleFor(x => x.Descricao).NotNull();
            });
        }
    }
}
