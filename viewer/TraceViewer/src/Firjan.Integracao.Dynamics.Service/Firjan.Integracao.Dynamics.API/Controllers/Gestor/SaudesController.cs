using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Microsoft.AspNetCore.Mvc;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class SaudesController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/Gestor/[controller]/{version}")]
    public class SaudesController : Base<SaudeViewModel, int>
    {
        public SaudesController(ISaudeAppService appService) : base(appService, "ProdutoId") { }
    }    
}