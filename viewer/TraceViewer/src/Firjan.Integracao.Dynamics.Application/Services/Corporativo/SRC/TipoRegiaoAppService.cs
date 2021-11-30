using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Application.Services.Base;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.SRC
{
    public class TipoRegiaoAppService : BaseAppService<TipoRegiao, TipoRegiaoViewModel>, ITipoRegiaoAppService
    {
        public TipoRegiaoAppService(IMapper mapper, ITipoRegiaoService service) : base(mapper, service) { }
    }
}
