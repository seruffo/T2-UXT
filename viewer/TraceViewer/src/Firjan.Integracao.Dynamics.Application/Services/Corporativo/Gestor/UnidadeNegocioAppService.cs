using AutoMapper;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{
    public class UnidadeNegocioAppService : BaseAppService<UnidadeNegocio, UnidadeNegocioViewModel>, IUnidadeNegocioAppService
    {
        public UnidadeNegocioAppService(IMapper mapper, IUnidadeNegocioService service) : base(mapper, service)
        {
        }
    }   
}
