using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Firjan.Integracao.Dynamics.Application.Interfaces;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.API.Controllers.Gestor
{
    ///<Summary>
    /// Class EnderecoUnidadeController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    public class EnderecosUnidadesController : ControllerBase
    {
        private readonly IEnderecoUnidadeAppService _enderecoUnidadeAppService;

        ///<Summary>
        /// Constructor EnderecoUnidadeController
        ///</Summary>
        public EnderecosUnidadesController(IEnderecoUnidadeAppService enderecoUnidadeAppService)
            : base() => _enderecoUnidadeAppService = enderecoUnidadeAppService;

        /// <summary>
        /// Retorna a lista de objeto Endereço Unidade de Negócio com os parâmetros colunaOrdenacao, direcao, qtd and pule
        /// </summary>
        /// <param name="colunaOrdenacao">Coluna de ordenação da coleção de retorno</param>
        /// <param name="direcao">Direção da ordenação da coleção de retorno</param>
        /// <param name="qtd">Quantidade da lista de retorno</param>
        /// <param name="pule">Pular específico número de elementos e retorna os elementos remanescentes</param>
        /// <response code="204">Retorna status sem conteúdo</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Microsoft.AspNetCore.Authorization.Authorize("Bearer")]
        [HttpGet("GetAll/{colunaOrdenacao}/{direcao}/{qtd}/{pule}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(IEnumerable<EnderecoUnidadeViewModel>), StatusCodes.Status200OK)]
        public IActionResult GetAll(string colunaOrdenacao = "Id", string direcao = "asc", int qtd = 50, int pule = 0)
        {
            var retorno = _enderecoUnidadeAppService.ComFiltros(colunaOrdenacao, direcao == "asc", null, qtd, pule).Result;

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
        /// Retorna o objeto Endereço Unidade de Negócio by PrimaryKey
        /// </summary>
        /// <param name="id">Id do objeto do retorno</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Microsoft.AspNetCore.Authorization.Authorize("Bearer")]
        [HttpGet("{id}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(EnderecoUnidadeViewModel), StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {
            var retorno = _enderecoUnidadeAppService.FirstOrDefault(c => c.Id == id).Result;

            return retorno != null ? (IActionResult)Ok(new
            {
                success = true,
                data = retorno
            }) : NoContent();
        }
    }
}