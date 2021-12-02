using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.SRC
{
    public class RegiaoAppService : BaseAppService<Regiao, RegiaoViewModel>, IRegiaoAppService
    {
        public static readonly string[] includes = { "TipoRegiao", "EnderecoUnidade" };
        public RegiaoAppService(IMapper mapper, IRegiaoService service) : base(mapper, service, includes) { }
    }
}
