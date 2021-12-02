using Firjan.Integracao.Dynamics.API.Base.Query;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Protheus;
using Microsoft.AspNetCore.Mvc;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class FiliaisController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/Gestor/Protheus/[controller]/{version}")]
    public class FiliaisController : Base<FilialViewModel, string>
    {
        ///<Summary>
        /// Constructor FiliaisController
        ///</Summary>
        public FiliaisController(IFilialAppService appService) : base(appService) { }
    }
}
