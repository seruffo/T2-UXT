using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Saude;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{
    public class SaudeAppService : BaseAppService<Domain.Models.Corporativo.Gestor.Saude, SaudeViewModel>, ISaudeAppService
    {
        public new static string[] includes = { "Produto", "ClassificacaoExame", "GrupoClassificacao" };
        public SaudeAppService(IMapper mapper, ISaudeService saudeService) : base(mapper, saudeService, includes) { }
    }
}
