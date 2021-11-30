using Microsoft.AspNetCore.Mvc;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.API.Base.CRUD;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class ProdutosUnidadesNegociosController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    [ApiController]
    public class ProdutosUnidadesNegociosController : Base<ProdutoUnidadeNegocioViewModel, int>
    {
        public ProdutosUnidadesNegociosController(IProdutoUnidadeNegocioAppService appService) : base(appService) { }
    }
}