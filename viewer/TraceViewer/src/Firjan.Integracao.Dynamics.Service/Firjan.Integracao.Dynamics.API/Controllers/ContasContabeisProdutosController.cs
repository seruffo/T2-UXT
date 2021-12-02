using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class ContasContabeisProdutosController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    public class ContasContabeisProdutosController : Base<ContaContabilProdutoViewModel, string>
    {
        ///<Summary>
        /// Constructor ContasContabeisProdutosController
        ///</Summary>
        public ContasContabeisProdutosController(IContaContabilProdutoAppService AppService) : base(AppService, "ProdutoId") { }

        /// <summary>
        /// Retorna o objeto Bairro by PrimaryKey
        /// </summary>
        /// <param name="CodigoEmpresa">Id do objeto do retorno</param>
        /// <param name="CodigoConta">Id do objeto do retorno</param>
        /// <param name="ProdutoId">Id do objeto do retorno</param>
        /// <param name="Inicio">Id do objeto do retorno</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet("{CodigoEmpresa}/{CodigoConta}/{ProdutoId}/{Inicio}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ContaContabilProdutoViewModel), StatusCodes.Status200OK)]
        public new IActionResult Get(string CodigoEmpresa, string CodigoConta, int? ProdutoId, DateTime? Inicio)
        {
            var retorno = appService.FirstOrDefault(c => c.CodigoEmpresa == CodigoEmpresa
            || c.CodigoConta == CodigoConta || c.ProdutoId == ProdutoId || c.Inicio == Inicio).Result;

            return retorno != null ? (IActionResult)Ok(new
            {
                success = true,
                data = retorno
            }) : NoContent();
        }
    }
}