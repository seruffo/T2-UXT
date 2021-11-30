using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Services.Base;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{
    public class CodigoMunicipalAppService : BaseAppService<CodigoMunicipal, CodigoMunicipalViewModel>, ICodigoMunicipalAppService
    {
        public CodigoMunicipalAppService(IMapper mapper, ICodigoMunicipalService service) : base(mapper, service) { }
    }
}
