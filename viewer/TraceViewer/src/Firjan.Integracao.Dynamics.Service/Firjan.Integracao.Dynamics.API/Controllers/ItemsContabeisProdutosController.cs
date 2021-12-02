using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Firjan.Integracao.Dynamics.API.Controllers
{ 
    ///<Summary>
    /// Class ItemsContabeisProdutosController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    public class ItemsContabeisProdutosController : Base<ItemContabilProdutoViewModel, string>
    {
        public ItemsContabeisProdutosController(IItemContabilProdutoAppService appService) : base(appService, "ProdutoId") { }

        /// <summary>
        /// Retorna o objeto Bairro by PrimaryKey
        /// </summary>
        /// <param name="CodigoEmpresa">Código ds ampresa do objeto do retorno</param>
        /// <param name="CodigoCentroResponsabilidade">Código do centro de responsabilidade do objeto do retorno</param>
        /// <param name="ProdutoId">Id do Produto do objeto do retorno</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet("{CodigoEmpresa}/{CodigoCentroResponsabilidade}/{ProdutoId}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ItemContabilProdutoViewModel), StatusCodes.Status200OK)]
        public new IActionResult Get(string CodigoEmpresa, string CodigoCentroResponsabilidade, int? ProdutoId)
        {
            var retorno = appService.FirstOrDefault(c => c.CodigoEmpresa == CodigoEmpresa
            || c.CodigoCentroResponsabilidade == CodigoCentroResponsabilidade || c.ProdutoId == ProdutoId).Result;

            return retorno != null ? (IActionResult)Ok(new
            {
                success = true,
                data = retorno
            }) : NoContent();
        }
    }    
}