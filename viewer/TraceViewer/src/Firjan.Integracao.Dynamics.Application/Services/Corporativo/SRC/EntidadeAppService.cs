using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.SRC;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.SRC
{
    public class EntidadeAppService : BaseAppService<Entidade, EntidadeViewModel>, IEntidadeAppService
    {
        public static readonly string[] includes = { "TipoEntidadeVinculo"};
        public EntidadeAppService(IMapper mapper, IEntidadeService service) : base(mapper, service, includes) { }
    }
}
