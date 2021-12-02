using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class ModulosVersoesController
    ///</Summary>
    [Produces("application/json")]
    public partial  class ModulosVersoesController : Base<ModuloVersaoViewModel, string>
    {
        public ModulosVersoesController(IModuloVersaoAppService appService) : base(appService, "Codigo") { }

        /// <summary>
        /// Retorna o objeto  by codigo e numero da versao
        /// </summary>
        /// <param name="codigo">Id do objeto do retorno</param>
        /// <param name="numeroVersao">Número da versao do objeto do retorno</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet]
        [Route("{codigo}/{numeroVersao}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public new IActionResult Get(string codigo, string numeroVersao)
        {
            var retorno = appService.FirstOrDefault(c => c.Codigo == codigo && c.NumeroVersao == numeroVersao);

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