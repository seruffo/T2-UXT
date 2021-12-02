#region Usings
using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services;
using Firjan.Integracao.Dynamics.Domain.Models;
#endregion

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{
    public class TraceAppService : BaseAppService<Trace, TraceViewModel> , ITraceAppService
    {
        public TraceAppService(IMapper mapper, ITraceService traceService) : base(mapper, traceService, null) { }
    }
}
