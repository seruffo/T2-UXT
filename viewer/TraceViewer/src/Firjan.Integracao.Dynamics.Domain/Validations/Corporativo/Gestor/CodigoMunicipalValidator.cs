using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class CodigoMunicipalValidator : AbstractValidator<CodigoMunicipal>
    {
       public CodigoMunicipalValidator()
       {
            RuleFor(e => e.Id).NotNull();
            RuleFor(e => e.Descricao).NotNull();
            RuleFor(e => e.MunicipioId).NotNull();
        }
    }
}
