using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Protheus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Firjan.Integracao.Dynamics.API.Base.Query;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class ClassesValoresController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    public class ClassesValoresController : Base<ClasseValorViewModel,string>
    {
        ///<Summary>
        /// Constructor ClassesValoresController
        ///</Summary>
        public ClassesValoresController(IClasseValorAppService appService) : base(appService) { }
        
        /// <summary>
        /// Retorna o objeto Classe de Valor by PrimaryKey
        /// </summary>
        /// <param name="id">Código da subconta do objeto do retorno</param>
        /// <param name="empresa">Código da empresa do objeto do retorno</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet("{id}/{empresa}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ClasseValorViewModel), StatusCodes.Status200OK)]
        public IActionResult Get(string id, string empresa)
        {          
            var retorno = appService.ComFiltros(null, null, f => f.Id == id && f.Empresa == empresa, 0, 0).Result;

            return retorno.Any()
                 ? Ok(new
                 {
                     success = true,
                     data = retorno.FirstOrDefault(),
                     totalCount = retorno.Count()
                 })
                 : (IActionResult)NoContent();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Get(string id) => NoContent();
    }
}