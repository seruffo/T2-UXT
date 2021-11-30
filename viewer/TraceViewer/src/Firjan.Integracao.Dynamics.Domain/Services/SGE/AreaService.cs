using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.SGE;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.SGE;
using Firjan.Integracao.Dynamics.Domain.Models.SGE;
using Firjan.Integracao.Dynamics.Domain.Services.Base;

namespace Firjan.Integracao.Dynamics.Domain.Services.SGE
{
    public class AreaService : BaseService<Area>, IAreaService
    {
        public AreaService(IAreaRepository repository) : base(repository) { }
    }
}
