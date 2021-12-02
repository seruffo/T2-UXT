using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Firjan.Integracao.Dynamics.Application.Utils;
using Firjan.Integracao.Dynamics.Application.Interfaces.Base;
using System.Linq.Expressions;

namespace Firjan.Integracao.Dynamics.API.Base.Query
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]/{version}")]
    public abstract class Base<V, T> : ControllerBase
        where V : Application.ViewModels.Corporativo.Base.Base
    {
        public T Id { get; set; }
        private string Campo { get; set; } = "Id";
        protected readonly IAppService<V> appService;
        protected Expression<Func<V, bool>> Filter { get; set; }

        ///<Summary>
        /// Constructor BaseGetController
        ///</Summary>
        protected Base(IAppService<V> _appService, string campo = null, Expression<Func<V, bool>> filter = null)
        {
            Filter = filter;
            Campo = campo ?? Campo;
            appService = _appService;
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
        public virtual IActionResult GetAll(string colunaOrdenacao = "id", string direcao = "asc", int qtd = 50, int pule = 0)
        {
            var retorno = appService.ComFiltros(Campo != colunaOrdenacao ? Campo : colunaOrdenacao, string.Compare(direcao, "asc", StringComparison.Ordinal) == 0, Filter, qtd, pule).Result.IfNotNull(on => on.ToList());

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
        /// Retorna o objeto  by id
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual IActionResult Get(T id)
        {
            var refId = id;

            var arg = Expression.Parameter(typeof(V), "x");

            var equals = Expression.Equal(
                Expression.Property(arg, Campo),
                Expression.Constant(refId)
            );

            var where = (Expression<Func<V, bool>>)Expression.Lambda(equals, arg);

            var retorno = appService.FirstOrDefault(where);

            return retorno.IsCompleted && retorno.Result != null
                ? Ok(new
                {
                    success = true,
                    data = retorno.GetAwaiter().GetResult()
                })
                : (IActionResult)NoContent();
        }
    }
}

namespace Firjan.Integracao.Dynamics.API.Base.CRUD
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]/{version}")]
    public abstract class Base<V, T> : Query.Base<V, T>
       where V : Application.ViewModels.Corporativo.Base.Base
    {

        ///<Summary>
        /// Constructor BaseGetController
        ///</Summary>
        protected Base(IAppService<V> _appService, string campo = null, Expression<Func<V, bool>> filter = null)
            : base(_appService,campo,filter) {}

        ///<summary>
        ///Criação do objeto />.
        ///</summary>.
        ///<param name='v'>Objeto </param>
        ///<response code="200">Retorna result sucesso com objeto criado e total</response>
        ///<response code="400">Retorna objeto result modelo inválido</response>
        [Authorize("Bearer")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> Post([FromBody]V v)
        {
          if (ModelState.IsValid)
            {
                var retorno = await appService.Adicionar(v);

                if (!retorno.ValidationResult.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest, retorno);
                else
                    return Ok(new
                    {
                        success = true,
                        data = retorno
                    });
            }
            return BadRequest(v);
        }

        ///<summary>
        ///Atualização do objeto .
        ///</summary>
        ///<param name='v'>Objeto </param>
        ///<response code="200">Retorna result sucesso com objeto criado e total</response>
        ///<response code="400">Retorna objeto result modelo inválido</response>
        [Authorize("Bearer")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> Put([FromBody]V v)
        {
            if (ModelState.IsValid)
            {
                var retorno = await appService.Atualizar(v);

                if (!retorno.ValidationResult.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest, retorno);
                else
                    return Ok(new
                    {
                        success = true,
                        data = retorno
                    });
            }
            return BadRequest(v);
        }

        ///<summary>
        ///Deleção do objeto .
        ///</summary>
        ///<param name='v'>Objeto </param>
        ///<response code="200">Retorna result sucesso com objeto criado e total</response>
        ///<response code="400">Retorna objeto result modelo inválido</response>
        [Authorize("Bearer")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> Delete([FromBody]V v)
        {
            if (ModelState.IsValid)
            {
                var retorno = await appService.Remover(v);

                if (!retorno.ValidationResult.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest, retorno);
                else
                    return Ok(new
                    {
                        success = true,
                        data = retorno
                    });
            }
            return BadRequest(v);
        }
    }
}