using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.STI;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.STI;
using Microsoft.AspNetCore.Mvc;
using Firjan.Integracao.Dynamics.API.Base.Query;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class FuncoesController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    public class FuncoesController : Base<FuncaoViewModel, string>
    {
        public FuncoesController(IFuncaoAppService appService) : base(appService, "Codigo") { }
    }
}