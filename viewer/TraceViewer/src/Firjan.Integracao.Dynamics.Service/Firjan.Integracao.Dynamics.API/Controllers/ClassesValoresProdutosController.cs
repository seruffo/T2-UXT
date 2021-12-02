using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using System;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class ClassesValoresProdutosController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    public class ClassesValoresProdutosController : ControllerBase
    {
        private readonly IClasseValorProdutoAppService _classeValorProdutoAppService;

        ///<Summary>
        /// Constructor ClassesValoresProdutosController
        ///</Summary>
        public ClassesValoresProdutosController(IClasseValorProdutoAppService classeValorProdutoAppService)
            : base() => _classeValorProdutoAppService = classeValorProdutoAppService;


        ///<summary>
        ///Criação do objeto Classe Valor Produto.
        ///</summary>
        ///<param name="classeValorProdutoViewModel">Criaçãodo Objeto Classe Valor Produto</param>
        ///<response code="200">Retorna result sucesso com objeto criado e total</response>
        ///<response code="400">Retorna objeto result modelo inválido</response>  
        [Authorize("Bearer")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ClasseValorProdutoViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody]ClasseValorProdutoViewModel classeValorProdutoViewModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = await _classeValorProdutoAppService.Adicionar(classeValorProdutoViewModel);

                if (!retorno.ValidationResult.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest, retorno);
                else
                    return Ok(new
                    {
                        success = true,
                        data = retorno
                    });
            }
            return BadRequest(classeValorProdutoViewModel);

        }

        ///<summary>
        ///Atualização do objeto Classe Valor Produto.
        ///</summary>
        ///<param name="classeValorProdutoViewModel">Atualização do Objeto Classe Valor Produto</param>
        ///<response code="200">Retorna result sucesso com objeto criado e total</response>
        ///<response code="400">Retorna objeto result modelo inválido</response>
        [Authorize("Bearer")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ClasseValorProdutoViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromBody]ClasseValorProdutoViewModel classeValorProdutoViewModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = await _classeValorProdutoAppService.Atualizar(classeValorProdutoViewModel);

                if (!retorno.ValidationResult.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest, retorno);
                else
                    return Ok(new
                    {
                        success = true,
                        data = retorno
                    });
            }
            return BadRequest(classeValorProdutoViewModel);
        }

        /// <summary>
        /// Retorna a lista de objeto Classes Valores Produtos com os parâmetros colunaOrdenacao, direcao, qtd and pule
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
        [ProducesResponseType(typeof(IEnumerable<ClasseValorProdutoViewModel>), StatusCodes.Status200OK)]
        public IActionResult GetAll(string colunaOrdenacao = "CodigoEmpresa", string direcao = "asc", int qtd = 50, int pule = 0)
        {
            var retorno = _classeValorProdutoAppService.ComFiltros(colunaOrdenacao, direcao == "asc", null , qtd, pule).Result;

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
        /// Retorna o objeto Bairro by PrimaryKey
        /// </summary>
        /// <param name="CodigoEmpresa">Codigo da empresa do objeto do retorno</param>
        /// <param name="CodigoCentroResponsabilidade">Codigo do centro de responsabilidade do objeto do retorno</param>
        /// <param name="ProdutoId">Id do Produto objeto do retorno</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet("{CodigoEmpresa}/{CodigoCentroResponsabilidade}/{ProdutoId}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ItemContabilProdutoViewModel), StatusCodes.Status200OK)]
        public IActionResult Get(string CodigoEmpresa, string CodigoCentroResponsabilidade, int ProdutoId)
        {
            var retorno = _classeValorProdutoAppService.FirstOrDefault(c => c.CodigoEmpresa == CodigoEmpresa
            || c.CodigoCentroResponsabilidade == CodigoCentroResponsabilidade || c.ProdutoId == ProdutoId).Result;

            return retorno != null ? (IActionResult)Ok(new
            {
                success = true,
                data = retorno
            }) : NoContent();
        }

        [Authorize("Bearer")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ClasseValorProdutoViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody]ClasseValorProdutoViewModel classeValorProdutoViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _classeValorProdutoAppService.Remover(classeValorProdutoViewModel);

                if (!result.ValidationResult.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest, result);
                else
                    return Ok(result);
            }
            return BadRequest(classeValorProdutoViewModel);
        }
    }
}