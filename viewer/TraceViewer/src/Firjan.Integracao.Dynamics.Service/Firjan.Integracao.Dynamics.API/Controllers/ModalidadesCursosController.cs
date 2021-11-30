using Firjan.Integracao.Dynamics.Application.Interfaces.SGE;
using Firjan.Integracao.Dynamics.Application.ViewModels.SGE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Firjan.Integracao.Dynamics.API.Base.Query;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class ModalidadesCursosController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    public class ModalidadesCursosController : Base<ModalidadeCursoViewModel, string>
    {
        ///<Summary>
        /// Constructor ModalidadesCursosController
        ///</Summary>
        public ModalidadesCursosController(IModalidadeCursoAppService appService)   : base(appService) { }

        /// <summary>
        /// Retorna o objeto Área by CodColigada
        /// </summary>
        /// <param name="CodColigada">Codigo coligada do objeto do retorno</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet]
        [Route("byColigada/{CodColigada}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ModalidadeCursoViewModel), StatusCodes.Status200OK)]
        public IActionResult Get(Int16 CodColigada)
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