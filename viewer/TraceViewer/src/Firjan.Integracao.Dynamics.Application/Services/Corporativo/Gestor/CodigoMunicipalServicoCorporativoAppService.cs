using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Services.Base;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{
    public class CodigoMunicipalServicoCorporativoAppService : BaseAppService<CodigoMunicipalServicoCorporativo, CodigoMunicipalServicoCorporativoViewModel>, ICodigoMunicipalServicoCorporativoAppService
    {
        public CodigoMunicipalServicoCorporativoAppService(IMapper mapper, ICodigoMunicipalServicoCorporativoService service) : base(mapper, service, null) { }
    }
}
