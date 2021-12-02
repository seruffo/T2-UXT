using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{
    public class ProdutoUnidadeNegocioAppService : BaseAppService<ProdutoUnidadeNegocio, ProdutoUnidadeNegocioViewModel>, IProdutoUnidadeNegocioAppService
    {
        public static readonly string[] includes = { "Produto", "UnidadeNegocio" };
        public ProdutoUnidadeNegocioAppService(IMapper mapper, IProdutoUnidadeNegocioService service) : base(mapper, service, includes) { }
    }
}
