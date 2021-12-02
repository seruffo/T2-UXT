using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.SGE;
using Firjan.Integracao.Dynamics.Application.ViewModels.SGE;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.SGE;
using Firjan.Integracao.Dynamics.Domain.Models.SGE;
using Firjan.Integracao.Dynamics.Application.Services.Base;

namespace Firjan.Integracao.Dynamics.Application.Services.SGE
{
    public class AreaAppService : BaseAppService<Area, AreaSGEViewModel>, IAreaAppService
    {
        public AreaAppService(IMapper mapper, IAreaService service) : base(mapper, service) { }
    }
}