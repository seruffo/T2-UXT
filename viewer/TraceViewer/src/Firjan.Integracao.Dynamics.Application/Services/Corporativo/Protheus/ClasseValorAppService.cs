using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Protheus
{
    public class ClasseValorAppService : BaseAppService<ClasseValor, ClasseValorViewModel>, IClasseValorAppService
    {
        public ClasseValorAppService(IMapper mapper, IClasseValorService saudeService) : base(mapper, saudeService) { }
    }
}