using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Saude;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class ProdutosTiposFichasController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/Gestor/Saude/[controller]/{version}")]
    public class ProdutosTiposFichasController : Base<ProdutoTipoFichaViewModel, int>
    {
        public ProdutosTiposFichasController(IProdutoTipoFichaAppService appService) : base(appService, "ProdutoId") { }

        /// <summary>
        /// Retorna o objeto  by ProdutoId, ServicoId e TipoFichaId
        /// </summary>
        /// <param name="ProdutoId">ProdutoId do objeto do retorno</param>
        /// <param name="ServicoId">ServicoId do objeto do retorno</param>
        /// <param name="TipoFichaId">TipoFichaId do objeto do retorno</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet("{ProdutoId}/{ServicoId}/{TipoFichaId}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public new IActionResult Get(int ProdutoId, int ServicoId, int TipoFichaId)
        {
            Expression<Func<ProdutoTipoFichaViewModel, bool>> where = c => c.ProdutoId == ProdutoId || c.ServicoId == ServicoId || c.TipoFichaId == TipoFichaId;

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
        public override IActionResult Get(int id) => NoContent();
    }
}