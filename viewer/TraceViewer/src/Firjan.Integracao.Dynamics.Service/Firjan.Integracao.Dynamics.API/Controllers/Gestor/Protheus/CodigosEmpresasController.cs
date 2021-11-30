using Firjan.Integracao.Dynamics.Application.Interfaces.Protheus;
using Firjan.Integracao.Dynamics.Application.ViewModels.Protheus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class CodigosEmpresasController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/Gestor/Protheus/[controller]/{version}")]
    public class CodigosEmpresasController : ControllerBase
    {
        private readonly IEmpresaAppService _empresaAppService;

        ///<Summary>
        /// Constructor EmpresasController
        ///</Summary>
        public CodigosEmpresasController(IEmpresaAppService empresaAppService)
            : base()
        {
            _empresaAppService = empresaAppService;
        }

        /// <summary>
        /// Retorna a lista de objeto Empresas com os parâmetros colunaOrdenacao, direcao, qtd and pule
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
        [ProducesResponseType(typeof(IEnumerable<EmpresaViewModel>), StatusCodes.Status200OK)]
        public IActionResult GetAll(string colunaOrdenacao = "Descricao", string direcao = "asc", int qtd = 50, int pule = 0)
        {
            var retorno = _empresaAppService.ComFiltros(colunaOrdenacao, direcao == "asc", null, qtd, pule).Result;

            return retorno.Any()
                ? Ok(new
                {
                    success = true,
                    data = retorno,
                    totalCount = retorno.Count()
                })
                : (IActionResult)NoContent();
        }

        /// <summary>
        /// Retorna o objeto Empresas by Código
        /// </summary>
        /// <param name="codigo">Código do objeto do retorno</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet("{codigo}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(EmpresaViewModel), StatusCodes.Status200OK)]
        public IActionResult Get(string codigo)
        {
            var retorno = _empresaAppService.ComFiltros(null, null, c => c.Id == codigo, 0, 0).Result;

            return retorno.Any()
                ? Ok(new
                {
                    success = true,
                    data = retorno.FirstOrDefault(),
                    totalCount = retorno.Count()
                })
                : (IActionResult)NoContent();
        }
    }
}