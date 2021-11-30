using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;

namespace Firjan.Integracao.Dynamics.API.Controllers.Gestor.Odontograma
{
    ///<Summary>
    /// Class SaudesFigurasOdontogramasController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/Gestor/Odontograma/[controller]/{version}")]
    public class SaudesFigurasOdontogramasController : Base<SaudeFiguraOdontogramaViewModel, int?>
    {
        public SaudesFigurasOdontogramasController(ISaudeFiguraOdontogramaAppService appService) : base(appService, "SaudeId") { }

        /// <summary>
        /// Retorna o objeto  by SaudeId e FiguraId
        /// </summary>
        /// <param name="SaudeId">SaudeId do objeto do retorno</param>
        /// <param name="FiguraOdontogramaId">SaudeId do objeto do retorno</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet("{SaudeId}/{FiguraOdontogramaId}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(int SaudeId, int? FiguraOdontogramaId)
        {
            Expression<Func<SaudeFiguraOdontogramaViewModel, bool>> where = c => c.SaudeId == SaudeId && c.FiguraOdontogramaId == FiguraOdontogramaId;
            var retorno = appService.FirstOrDefault(where);

            return retorno.IsCompleted && retorno.Result != null
                ? Ok(new
                {
                    success = true,
                    data = retorno.GetAwaiter().GetResult()
                })
                : (IActionResult)NoContent();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Get(int? id)
        {
            return NoContent();
        }

    }
}