using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.SMAIS;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.SMAIS;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.SMAIS;
using Firjan.Integracao.Dynamics.Domain.Models.SMAIS;

namespace Firjan.Integracao.Dynamics.Application.Services.SMAIS
{
    public class ExameAppService : BaseAppService<Exame, ExameViewModel>, IExameAppService
    {
        public ExameAppService(IMapper mapper, IExameService service) : base(mapper, service) { }
    }
}
