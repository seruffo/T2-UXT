using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.SRC
{
    public class RegiaoUnidadeNegocioAppService : BaseAppService<RegiaoUnidadeNegocio, RegiaoUnidadeNegocioViewModel>, IRegiaoUnidadeNegocioAppService
    {
        public static readonly string[] includes = { "Regiao", "UnidadeNegocio", "TipoRegiao" };
        public RegiaoUnidadeNegocioAppService(IMapper mapper, IRegiaoUnidadeNegocioService service) : base(mapper, service, includes) { }
    }
}
