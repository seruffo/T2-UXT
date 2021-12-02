using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using System.Collections.Generic;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{
    public class ClassificacaoAppService : BaseAppService<Classificacao, ClassificacaoViewModel>, IClassificacaoAppService
    {
        private static IEnumerable<string> Includes => new string[] { "GrupoClassificacao", "Produto" };
        public ClassificacaoAppService(IMapper mapper, IClassificacaoService service) : base(mapper, service, Includes) { }
    }
}