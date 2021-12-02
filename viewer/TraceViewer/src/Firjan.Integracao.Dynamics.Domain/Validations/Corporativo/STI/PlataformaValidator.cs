using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.STI
{
    public class PlataformaValidator : AbstractValidator<Plataforma>
    {
       public PlataformaValidator()
       {
            RuleFor(e => e.Id)
                .NotNull();            

            RuleFor(e => e.Descricao)
                .NotNullNotEmpty()
                .WithMessage("{PropertyName} must contain 80 caracters");

            RuleFor(e => e.CodigoArea)
                .NotNullNotEmpty()
                .WithMessage("{PropertyName} must contain 5 caracters");         
        }

    }
}
