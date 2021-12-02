using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Gestor
{
    public class CodigoMunicipalService : BaseService<CodigoMunicipal>, ICodigoMunicipalService
    {
        public CodigoMunicipalService(ICodigoMunicipalRepository repository, CodigoMunicipalValidator validator) : base(repository, validator) { }
    }
}
