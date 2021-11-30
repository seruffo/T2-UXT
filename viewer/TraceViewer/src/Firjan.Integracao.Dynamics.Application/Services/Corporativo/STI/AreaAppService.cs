using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.STI;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;


namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.STI
{
    public class AreaAppService : BaseAppService<Area, AreaViewModel>, IAreaAppService
    {
        public AreaAppService(IMapper mapper, IAreaService service) : base(mapper, service, null) { }
    }
}