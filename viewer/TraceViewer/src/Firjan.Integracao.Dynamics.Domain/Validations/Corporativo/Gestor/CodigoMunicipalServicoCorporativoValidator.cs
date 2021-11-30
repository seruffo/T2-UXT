using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor
{
    public class CodigoMunicipalServicoCorporativoValidator : AbstractValidator<CodigoMunicipalServicoCorporativo>
    {
        public CodigoMunicipalServicoCorporativoValidator()
       {
            RuleFor(e => e.CodigoServicoOficial).NotNull();
            RuleFor(e => e.Inicio).NotNull();
            RuleFor(e => e.CodigoMunicipio).NotNull();
            RuleFor(e => e.CodigoMunicipalId).NotNull();
        }

    }
}
