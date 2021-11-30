using Firjan.Integracao.Dynamics.API.Base.Query;
using Firjan.Integracao.Dynamics.Application.Interfaces.SGE;
using Firjan.Integracao.Dynamics.Application.ViewModels.SGE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Firjan.Integracao.Dynamics.API.Controllers
{

    ///<Summary>
    /// Class AreasSgeController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    public class AreasSgeController : Base<AreaSGEViewModel,Int16>
    {
        ///<Summary>
        /// Constructor AreasSgeController
        ///</Summary>
        public AreasSgeController(IAreaAppService appService) : base(appService) { }
        
        /// <summary>
        /// Retorna o objeto Área SGE by CodColigada
        /// </summary>
        /// <param name="CodColigada">Codigo coligada do objeto do retorno</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet]
        [Route("ByColigada/{CodColigada}")]
        [ActionName(nameof(GetByColigada))]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(AreaSGEViewModel), StatusCodes.Status200OK)]
        public IActionResult GetByColigada(Int16 CodColigada)
        {
            var retorno = appService.ComFiltros(null, null, c => c.ColigadaId == CodColigada, 0, 0).Result;

            return retorno.Any()
                ? Ok(new
                {
                    success = true,
                    data = retorno,
                    totalCount = retorno.Count()
                })
                : (IActionResult)NoContent();
        }
    }
}