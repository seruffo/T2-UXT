using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.Interfaces.SMAIS;
using Firjan.Integracao.Dynamics.Application.ViewModels.SMAIS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class ExamesController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/SMAIS/[controller]/{version}")]
    public class ExamesController : Base<ExameViewModel, int?>
    {
        public ExamesController(IExameAppService appService) : base(appService, "COD") { }        
        
        [ApiExplorerSettings(IgnoreApi = true)]
        public override async Task<IActionResult> Post([FromBody]ExameViewModel v)
        {
            return await Task.FromResult(NoContent());
        }
      
        [ApiExplorerSettings(IgnoreApi = true)]
        public override async Task<IActionResult> Put([FromBody]ExameViewModel v)
        {
            return await Task.FromResult(NoContent());
        }
      
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Get(int? id)
        {
            return NoContent();
        }
    }
}