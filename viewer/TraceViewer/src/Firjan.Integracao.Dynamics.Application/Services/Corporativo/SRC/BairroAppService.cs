using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.SRC
{
    public class BairroAppService : BaseAppService<Bairro, BairroViewModel>, IBairroAppService
    {
        public BairroAppService(IMapper mapper, IBairroService service) : base(mapper, service) { }
    }
}
