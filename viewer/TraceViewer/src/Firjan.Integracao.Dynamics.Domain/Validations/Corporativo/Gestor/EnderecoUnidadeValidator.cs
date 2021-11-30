using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class EnderecoUnidadeValidator : AbstractValidator<EnderecoUnidade>
    {
       public EnderecoUnidadeValidator()
       {
            RuleFor(e => e.Id)
                .NotNull()
                .WithMessage("{PropertyName} must not be null");

            //RuleFor(e => e.UnidadeNegocioId)
            //    .NotNull()
            //    .WithMessage("{PropertyName} must not be null");

            //RuleFor(e => e.MunicipioId)
            //    .NotNull()
            //    .WithMessage("{PropertyName} must not be null");

        }

    }
}
