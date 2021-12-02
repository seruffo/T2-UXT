using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Protheus;
using Microsoft.AspNetCore.Mvc;
using Firjan.Integracao.Dynamics.API.Base.Query;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class ContasContabeisController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    public class ContasContabeisController : Base<ContaContabilViewModel,string>
    {
        ///<Summary>
        /// Constructor ContasContabeisController
        ///</Summary>
        public ContasContabeisController(IContaContabilAppService appService) : base(appService) { }        
    }
}