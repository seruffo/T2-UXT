#region Usings
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services;
using Firjan.Integracao.Dynamics.Domain.Models;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations;
#endregion

namespace Firjan.Integracao.Dynamics.Domain.Services
{
    public class TraceService : BaseService<Trace>, ITraceService
    {
        public TraceService(ITraceRepository repository, TraceValidator validator) : base(repository, validator) { }
    }
}
