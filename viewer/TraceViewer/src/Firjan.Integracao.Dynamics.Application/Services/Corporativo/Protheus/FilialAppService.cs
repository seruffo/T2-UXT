using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Protheus
{
    public class FilialAppService : BaseAppService<Filial, FilialViewModel>, IFilialAppService
    {
        public FilialAppService(IMapper mapper, IFilialService service) : base(mapper, service) { }
    }
}