using System;
using System.Collections.Generic;
using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class TiposRegioesController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    public class RegioesUnidadesNegociosController : Base<RegiaoUnidadeNegocioViewModel, short>
    {
        public RegioesUnidadesNegociosController(IRegiaoUnidadeNegocioAppService appService) : base(appService, "Inicio") { }


        /// <summary>
        /// Retorna o objeto Região Unidade de Negócio by PrimaryKey
        /// </summary>
        /// <param name="tipoRegiaoId">Código do tipo de região do objeto do retorno</param>
        /// <param name="regiaoId">Id da região do objeto de retorno</param>
        /// <param name="unidadeNegocioId">Id da unidade de negócio do objeto de retorno</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet("GetByPrimaryKey/{tipoRegiaoId}/{regiaoId}/{unidadeNegocioId}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(IEnumerable<RegiaoUnidadeNegocioViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetByPrimaryKey(Int16 tipoRegiaoId, int regiaoId, int unidadeNegocioId)
        {
            var retorno = appService.FirstOrDefault(c => c.TipoRegiaoId == tipoRegiaoId && c.RegiaoId == regiaoId &&
                    c.UnidadeNegocioId == unidadeNegocioId, null);
            
            return retorno.IsCompleted && retorno.Result != null
                ? Ok(new
                {
                    success = true,
                    data = retorno.GetAwaiter().GetResult()
                })
                : (IActionResult)NoContent();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Get(short id) { return NoContent(); }
    }    
}
