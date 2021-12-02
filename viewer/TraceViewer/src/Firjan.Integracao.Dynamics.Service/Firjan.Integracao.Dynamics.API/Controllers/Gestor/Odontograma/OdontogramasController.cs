using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Odontograma;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;

namespace Firjan.Integracao.Dynamics.API.Controllers.Gestor.Odontograma
{
    ///<Summary>
    /// Class OdontogramasController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/Gestor/Odontograma/[controller]/{version}")]
    public class OdontogramasController : Base<OdontogramaViewModel, Byte?>
    {
        public OdontogramasController(IOdontogramaAppService appService) : base(appService, "PessoaId") { }

        /// <summary>
        /// Retorna o objeto  by SaudeId e FiguraId
        /// </summary>
        /// <param name="PessoaId">pessoaId do objeto do retorno</param>
        /// <param name="NumeroDente">NumeroDente do objeto do retorno</param>
        /// <param name="FiguraOdontogramaId">FiguraOdontogramaId do objeto do retorno</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet("{PessoaId}/{NumeroDente}/{FiguraOdontogramaId}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(int PessoaId, int NumeroDente, int FiguraOdontogramaId)
        {
            Expression<Func<OdontogramaViewModel, bool>> where = c => c.PessoaId == PessoaId || c.NumeroDente == NumeroDente || c.FiguraOdontogramaId == FiguraOdontogramaId;

            var retorno = appService.FirstOrDefault(where);

            return retorno.IsCompleted
                ? Ok(new
                {
                    success = true,
                    data = retorno.GetAwaiter().GetResult()
                })
                : (IActionResult)NoContent();

        }
       
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Get(Byte? id) => NoContent();
    }
}