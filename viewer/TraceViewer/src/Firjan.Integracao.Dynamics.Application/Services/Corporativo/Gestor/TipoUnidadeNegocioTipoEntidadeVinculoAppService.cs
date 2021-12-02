using AutoMapper;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{

    public class TipoUnidadeNegocioTipoEntidadeVinculoAppService : BaseAppService<TipoUnidadeNegocioTipoEntidadeVinculo, TipoUnidadeNegocioTipoEntidadevinculoViewModel>, ITipoUnidadeNegocioTipoEntidadeVinculoAppService
    {
        public static readonly string[] includes = { "TipoUnidadeNegocio", "TipoEntidadeVinculo" };
        public TipoUnidadeNegocioTipoEntidadeVinculoAppService(IMapper mapper, ITipoUnidadeNegocioTipoEntidadeVinculoService service) : base(mapper, service, includes) { }
    }
}
