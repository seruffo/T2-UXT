using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.Interfaces.SMAIS;
using Firjan.Integracao.Dynamics.Application.ViewModels.SMAIS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class RiscosController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/SMAIS/[controller]/{version}")]
    public class RiscosController : Base<RiscoViewModel, int?>
    {
        public RiscosController(IRiscoAppService appService) : base(appService, "COD") { }        
       
        [ApiExplorerSettings(IgnoreApi = true)]
        public override async Task<IActionResult> Post([FromBody]RiscoViewModel v)
        {
            return await Task.FromResult(NoContent());
        }
      
        [ApiExplorerSettings(IgnoreApi = true)]
        public override async Task<IActionResult> Put([FromBody]RiscoViewModel v)
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