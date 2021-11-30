using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.STI;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.STI
{
    public class LinhaServicoAppService : BaseAppService<LinhaServico, LinhaServicoViewModel>, ILinhaServicoAppService
    {
        public static readonly string[] includes = { "Funcao" };
        public LinhaServicoAppService(IMapper mapper, ILinhaServicoService linhaServicoService) : base(mapper, linhaServicoService, includes) { }
    }
}