using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.API.Base.Query;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Protheus;
using Microsoft.AspNetCore.Mvc;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class CentrosCustosController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/Protheus/[controller]/{version}")]
    public class CentrosCustosController : Base<CentroCustoViewModel,string>
    {
        ///<Summary>
        /// Constructor CentrosCustosController
        ///</Summary>
        public CentrosCustosController(ICentroCustoAppService appService) : base(appService) { }        
    }
}