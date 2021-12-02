using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Saude
{
    public class TipoFichaAppService : BaseAppService<TipoFicha, TipoFichaViewModel>, ITipoFichaAppService
    {
        public TipoFichaAppService(IMapper mapper, ITipoFichaService service) : base(mapper, service, null) { }
    }
}