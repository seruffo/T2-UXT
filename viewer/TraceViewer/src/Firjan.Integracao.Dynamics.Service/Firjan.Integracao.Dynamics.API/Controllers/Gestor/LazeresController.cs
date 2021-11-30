using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Microsoft.AspNetCore.Mvc;

namespace Firjan.Integracao.Dynamics.API.Controllers.Gestor
{
    ///<Summary>
    /// Class LazeresController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/Gestor/[controller]/{version}")]
    public class LazeresController : Base<LazerViewModel, int>
    {
        public LazeresController(ILazerAppService appService) : base(appService) { }
    }    
}