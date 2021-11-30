using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Firjan.Integracao.Dynamics.Application.ViewModels;
using Firjan.Integracao.Dynamics.Application.Interfaces;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class DiscadosUnidadesController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    public class DiscadosUnidadesController : ControllerBase
    {
        private readonly IDiscadoUnidadeAppService _discadoUnidadeAppService;

        ///<Summary>
        /// Constructor DiscadosUnidadesController
        ///</Summary>
        public DiscadosUnidadesController(IDiscadoUnidadeAppService discadoUnidadeAppService)
            : base() => _discadoUnidadeAppService = discadoUnidadeAppService;


        ///<summary>
        ///Criação do objeto Discado Unidade.
        ///</summary>
        ///<param name="discadoUnidadeViewModel">Objeto Disacado Unidade de Negócio</param>
        ///<response code="200">Retorna result sucesso com objeto criado e total</response>
        ///<response code="400">Retorna objeto result modelo inválido</response>  
        [Authorize("Bearer")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody]DiscadoUnidadeViewModel discadoUnidadeViewModel)
        {
            if (ModelState.IsValid)
            {
                await _discadoUnidadeAppService.Adicionar(discadoUnidadeViewModel);
                return Ok(discadoUnidadeViewModel);
            }
            return BadRequest(discadoUnidadeViewModel);
        }

        ///<summary>
        ///Atualização do objeto Discado Unidade.
        ///</summary>
        ///<param name="discadoUnidadeViewModel">Objeto Disacado Unidade de Negócio</param>
        ///<response code="200">Retorna result sucesso com objeto criado e total</response>
        ///<response code="400">Retorna objeto result modelo inválido</response>
        [Authorize("Bearer")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromBody]DiscadoUnidadeViewModel discadoUnidadeViewModel)
        {
            if (ModelState.IsValid)
            {
                await _discadoUnidadeAppService.Atualizar(discadoUnidadeViewModel);
                return Ok(discadoUnidadeViewModel);
            }
            return BadRequest(discadoUnidadeViewModel);
        }

        /// <summary>
        /// Retorna a lista de objeto Discado Unidade com os parâmetros colunaOrdenacao, direcao, qtd and pule
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
        [ProducesResponseType(typeof(IEnumerable<DiscadoUnidadeViewModel>), StatusCodes.Status200OK)]
        public IActionResult GetAll(string colunaOrdenacao = "Descricao", string direcao = "asc", int qtd = 50, int pule = 0)
        {
            var retorno = _discadoUnidadeAppService.ComFiltros(colunaOrdenacao, direcao == "asc", null, qtd, pule, null).Result;

            return retorno.Any()
                ? Ok(new
                {
                    success = true,
                    data = retorno.AsEnumerable(),
                    totalCount = retorno.Count()
                })
                : (IActionResult)NoContent();
        }

        /// <summary>
        /// Retorna o objeto Discado Unidade by PrimaryKey
        /// </summary>
        /// <param name="id">Id do objeto do retorno</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet("{id}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(DiscadoUnidadeViewModel), StatusCodes.Status200OK)]
        public IActionResult Get(string id)
        {
            var retorno = _discadoUnidadeAppService.ComFiltros(null, null, c => c.Id == int.Parse(id), 0, 0, null).Result;

            return retorno.Any()
                ? Ok((
                    success: true,
                    data: retorno.FirstOrDefault(),
                    totalCount: retorno.Count()
                ))
                : (IActionResult)NoContent();
        }
    }
}