using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class RegioesController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    public class RegioesController : Base<RegiaoViewModel, int>
    {
        ///<Summary>
        /// Constructor RegiaoController
        ///</Summary>
        public RegioesController(IRegiaoAppService AppService) : base(AppService) { }

        /// <summary>
        /// Retorna o objeto Região by Tipo Regiao
        /// </summary>
        /// <param name="tipoRegiaoId">Id do objeto do retorno</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet("GetByTipoRegiao/{tipoRegiaoId}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(RegiaoViewModel), StatusCodes.Status200OK)]
        public IActionResult GetByTipoRegiao(int tipoRegiaoId)
        {
            var retorno = appService.ComFiltros(null, null, c => c.TipoRegiaoId == tipoRegiaoId, 0, 0).Result;

            return retorno.Any()
                ? Ok(new
                {
                    success = true,
                    data = retorno.AsEnumerable(),
                    totalCount = retorno.Count()
                })
                : (IActionResult)NoContent();
        }
    }

    /////<Summary>
    ///// Class RegiaoController
    /////</Summary>
    //[ApiVersion("1")]
    //[Route("api/[controller]/{version}")]
    //[ApiController]
    //public class RegioesController : ControllerBase
    //{
    //    private readonly IRegiaoAppService _regiaoAppService;

    //    ///<Summary>
    //    /// Constructor RegiaoController
    //    ///</Summary>
    //    public RegioesController(IRegiaoAppService regiaoAppService)
    //        : base() => _regiaoAppService = regiaoAppService;


    //    ///<summary>
    //    ///Criação do objeto Região.
    //    ///</summary>
    //    ///<param name="regiaoViewModel">Objeto Entidade</param>
    //    ///<response code="200">Retorna result sucesso com objeto criado e total</response>
    //    ///<response code="400">Retorna objeto result modelo inválido</response>  
    //    [Authorize("Bearer")]
    //    [HttpPost]
    //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //    [ProducesResponseType(StatusCodes.Status200OK)]
    //    public async Task<IActionResult> Post([FromBody]RegiaoViewModel regiaoViewModel)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var result = await _regiaoAppService.Adicionar(regiaoViewModel);

    //            if (!result.ValidationResult.IsValid)
    //                return StatusCode(StatusCodes.Status400BadRequest, result);
    //            else
    //                return Ok(result);
    //        }
    //        return BadRequest(regiaoViewModel);
    //    }

    //    ///<summary>
    //    ///Atualização do objeto Região.
    //    ///</summary>
    //    ///<param name="regiaoViewModel">Objeto Regiao</param>
    //    ///<response code="200">Retorna result sucesso com objeto criado e total</response>
    //    ///<response code="400">Retorna objeto result modelo inválido</response>
    //    [Authorize("Bearer")]
    //    [HttpPut]
    //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //    [ProducesResponseType(StatusCodes.Status200OK)]
    //    public async Task<IActionResult> Put([FromBody]RegiaoViewModel regiaoViewModel)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var result = await _regiaoAppService.Atualizar(regiaoViewModel);

    //            if (!result.ValidationResult.IsValid)
    //                return StatusCode(StatusCodes.Status400BadRequest, result);
    //            else
    //                return Ok(result);
    //        }
    //        return BadRequest(regiaoViewModel);
    //    }

    //    /// <summary>
    //    /// Retorna a lista de objeto Região com os parâmetros colunaOrdenacao, direcao, qtd and pule
    //    /// </summary>
    //    /// <param name="colunaOrdenacao">Coluna de ordenação da coleção de retorno</param>
    //    /// <param name="direcao">Direção da ordenação da coleção de retorno</param>
    //    /// <param name="qtd">Quantidade da lista de retorno</param>
    //    /// <param name="pule">Pular específico número de elementos e retorna os elementos remanescentes</param>
    //    /// <response code="204">Retorna status sem conteúdo</response>
    //    /// <response code="200">Retorna result sucesso com objeto criado e total</response>
    //    [Authorize("Bearer")]
    //    [HttpGet("GetAll/{colunaOrdenacao}/{direcao}/{qtd}/{pule}")]
    //    [ProducesResponseType(StatusCodes.Status204NoContent)]
    //    [ProducesResponseType(typeof(IEnumerable<RegiaoViewModel>), StatusCodes.Status200OK)]
    //    public IActionResult GetAll(string colunaOrdenacao = "Descricao", string direcao = "asc", int qtd = 50, int pule = 0)
    //    {
    //        var retorno = _regiaoAppService.ComFiltros(colunaOrdenacao, direcao == "asc", null, qtd, pule, null).Result;

    //        return retorno.Any()
    //            ? Ok(new
    //            {
    //                success = true,
    //                data = retorno.AsEnumerable(),
    //                totalCount = retorno.Count()
    //            })
    //            : (IActionResult)NoContent();
    //    }


    //    /// <summary>
    //    /// Retorna o objeto Região by PrimaryKey
    //    /// </summary>
    //    /// <param name="id">Id do objeto do retorno</param>
    //    /// <response code="204">Retorna o status do objeto não achado</response>
    //    /// <response code="400">Retorna objeto result modelo inválido</response>
    //    /// <response code="200">Retorna result sucesso com objeto criado e total</response>
    //    [Authorize("Bearer")]
    //    [HttpGet("{id}")]
    //    [ApiExplorerSettings(GroupName = "v1")]
    //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //    [ProducesResponseType(StatusCodes.Status204NoContent)]
    //    [ProducesResponseType(typeof(RegiaoViewModel), StatusCodes.Status200OK)]
    //    public IActionResult Get(int id)
    //    {
    //        var retorno = _regiaoAppService.ComFiltros(null, null, c => c.Id == id, 0, 0, null).Result;

    //        return retorno.Any()
    //            ? Ok(new
    //            {
    //                success = true,
    //                data = retorno.FirstOrDefault(),
    //                totalCount = retorno.Count()
    //            })
    //            : (IActionResult)NoContent();
    //    }
        
    //    /// <summary>
    //    /// Retorna o objeto Região by Tipo Regiao
    //    /// </summary>
    //    /// <param name="tipoRegiaoId">Id do objeto do retorno</param>
    //    /// <response code="204">Retorna o status do objeto não achado</response>
    //    /// <response code="400">Retorna objeto result modelo inválido</response>
    //    /// <response code="200">Retorna result sucesso com objeto criado e total</response>
    //    [Authorize("Bearer")]
    //    [HttpGet("GetByTipoRegiao/{tipoRegiaoId}")]
    //    [ApiExplorerSettings(GroupName = "v1")]
    //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //    [ProducesResponseType(StatusCodes.Status204NoContent)]
    //    [ProducesResponseType(typeof(RegiaoViewModel), StatusCodes.Status200OK)]
    //    public IActionResult GetByTipoRegiao(int tipoRegiaoId)
    //    {
    //        var retorno = _regiaoAppService.ComFiltros(null, null, c => c.TipoRegiaoId == tipoRegiaoId, 0, 0, null).Result;

    //        return retorno.Any()
    //            ? Ok(new
    //            {
    //                success = true,
    //                data = retorno.AsEnumerable(),
    //                totalCount = retorno.Count()
    //            })
    //            : (IActionResult)NoContent();
    //    }
    //}
}