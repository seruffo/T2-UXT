using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.SMAIS;
using Firjan.Integracao.Dynamics.Domain.Models.SMAIS;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.SMAIS;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.SMAIS;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Gestor
{
    public class RiscoService : BaseService<Risco>, IRiscoService
    {
        public RiscoService(IRiscoRepository repository, RiscoValidator validator) : base(repository, validator) { }
    }
}
