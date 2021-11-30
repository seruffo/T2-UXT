using Microsoft.AspNetCore.Mvc;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class CodigosMunicipaisServicosCorporativosController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    public class CodigosMunicipaisServicosCorporativosController : Base<CodigoMunicipalServicoCorporativoViewModel, int?>
    {
        public CodigosMunicipaisServicosCorporativosController(ICodigoMunicipalServicoCorporativoAppService appService) : base(appService, "CodigoServicoOficial") { }

        /// <summary>
        /// Retorna o objeto by código municipio e código produto 
        /// </summary>
        /// <param name="CodigoMunicipio">Código do municipio</param>
        /// <param name="CodigoServicoOficial">Código do produto</param>
        /// <response code="204">Retorna o status do objeto não achado</response>
        /// <response code="400">Retorna objeto result modelo inválido</response>
        /// <response code="200">Retorna result sucesso com objeto criado e total</response>
        [Authorize("Bearer")]
        [HttpGet("{CodigoMunicipio}/{CodigoServicoOficial}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(string CodigoMunicipio, int CodigoServicoOficial)
        {
            var retorno = appService.FirstOrDefault(c => c.CodigoMunicipio == CodigoMunicipio && c.CodigoServicoOficial == CodigoServicoOficial && c.Fim == null);

            return retorno.IsCompleted && retorno.Result != null
                ? Ok(new
                {
                    success = true,
                    data = retorno.GetAwaiter().GetResult()
                })
                : (IActionResult)NoContent();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Get(int? id) => NoContent();
    }
}