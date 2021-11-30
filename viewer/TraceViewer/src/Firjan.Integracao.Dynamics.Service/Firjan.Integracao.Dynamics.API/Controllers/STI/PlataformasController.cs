using Firjan.Integracao.Dynamics.API.Base.Query;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.STI;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.STI;
using Microsoft.AspNetCore.Mvc;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class PlataformasController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/STI/[controller]/{version}")]
    public class PlataformasController : Base<PlataformaViewModel, int>
    {
        public PlataformasController(IPlataformaAppService appService) : base(appService) { }
    }      
}