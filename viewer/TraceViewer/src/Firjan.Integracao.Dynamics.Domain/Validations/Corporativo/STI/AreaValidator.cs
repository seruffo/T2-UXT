using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.STI
{
    public class AreaValidator : AbstractValidator<Area>
    {
       public AreaValidator()
       {
            RuleFor(e => e.Descricao)
                .NotNullNotEmpty()
                .MaximumLength(255)
                .WithMessage("{PropertyName} must contain 255 caracters");                

            RuleFor(e => e.CodigoDnaArea)
                .NotNullNotEmpty()
                .MaximumLength(3)
                .WithMessage("{PropertyName} must contain 3 caracters");         
        }

    }
}
