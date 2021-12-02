#region Usings
using Firjan.Integracao.Dynamics.API.Base.Query;
using Firjan.Integracao.Dynamics.Application.Interfaces;
using Firjan.Integracao.Dynamics.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace Firjan.Integracao.Dynamics.API.Controllers.Gestor
{
    ///<Summary>
    /// Class TraceController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    public class TraceController : Base<TraceViewModel, string>
    {
        public TraceController(ITraceAppService appService) : base(appService) { }       
    }
}