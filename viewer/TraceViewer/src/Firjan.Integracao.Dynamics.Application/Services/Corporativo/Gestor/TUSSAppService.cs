using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{
    public class TUSSAppService : BaseAppService<TUSS, TUSSViewModel> , ITUSSAppService
    {
        public TUSSAppService(IMapper mapper, ITUSSService tussService) : base(mapper, tussService, null) { }
    }
}
