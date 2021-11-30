using Microsoft.AspNetCore.Mvc;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    [Route("api/[controller]/{version}")]
    public class PingsController : Controller
    {
        /// <summary>
        /// Action para testes de disponibilidade. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get() => Ok("Pong");
    }
}
