using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.STI;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.STI
{
    public class FuncaoAppService : BaseAppService<Funcao, FuncaoViewModel>, IFuncaoAppService
    {
        public FuncaoAppService(IMapper mapper, IFuncaoService service) : base(mapper, service, null) { }
    }
}