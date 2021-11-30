using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{
    public class TipoEntidadeVinculoAppService : BaseAppService<TipoEntidadeVinculo, TipoEntidadeVinculoViewModel>, ITipoEntidadeVinculoAppService
    {
        public TipoEntidadeVinculoAppService(IMapper mapper, ITipoEntidadeVinculoService tipoEntidadeVinculoService) : base(mapper, tipoEntidadeVinculoService, null, null) {  }
    }
}
