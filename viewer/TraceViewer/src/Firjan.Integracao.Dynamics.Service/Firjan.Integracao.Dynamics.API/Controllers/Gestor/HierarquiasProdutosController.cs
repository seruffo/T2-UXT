using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Firjan.Integracao.Dynamics.Application.Utils;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class HierarquiasProdutosController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/Gestor/[controller]/{version}")]
    public class HierarquiasProdutosController : Base<GrupoClassificacaoViewModel, int>
    {
        private readonly IHierarquiaProdutoAppService _appService;
        public HierarquiasProdutosController(IHierarquiaProdutoAppService appService) : base(appService, "Id") { _appService = appService; }

        /// <summary>
        /// Retorna o objeto Hierarquia by CodigoEntidade
        /// </summary>
        /// <param name="CodigoEntidade">Código do objeto do retorno</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet("ByCodigoEntidade/{CodigoEntidade}")]
        [ActionName(nameof(GetByCodigoEntidade))]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(GrupoClassificacaoViewModel), StatusCodes.Status200OK)]
        public IActionResult GetByCodigoEntidade(string CodigoEntidade)
        {
            var retorno = _appService.ComFiltrosEntidades(null, null, c => c.Id == CodigoEntidade, 0, 0).Result;

            return retorno != null
                ? Ok(new
                {
                    success = true,
                    data = retorno
                })
                : (IActionResult)NoContent();
        }

        /// <summary>
        /// Retorna a lista do objeto com os parâmetros colunaOrdenacao, direcao, qtd and pule        
        /// </summary>
        /// <param name="colunaOrdenacao">Coluna de ordenação da coleção de retorno</param>
        /// <param name="direcao">Direção da ordenação da coleção de retorno</param>
        /// <param name="qtd">Quantidade da lista de retorno</param>
        /// <param name="pule">Pular específico número de elementos e retorna os elementos remanescentes</param>
        /// <response code="204">Retorna status sem conteúdo</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet("GetAll/{colunaOrdenacao}/{direcao}/{qtd}/{pule}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public override IActionResult GetAll(string colunaOrdenacao = "id", string direcao = "asc", int qtd = 50, int pule = 0)
        {
            var retorno = _appService.ComFiltrosEntidades(null, string.Compare(direcao, "asc", StringComparison.Ordinal) == 0, null, qtd, pule).Result.IfNotNull(on => on.ToList());

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
