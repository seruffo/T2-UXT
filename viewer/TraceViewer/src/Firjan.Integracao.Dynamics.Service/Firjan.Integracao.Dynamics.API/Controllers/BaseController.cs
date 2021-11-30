using Microsoft.AspNetCore.Mvc;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IActionResult Resposta(object result = null, int _totalCount = 0) => result != null ? (IActionResult)Ok(new
        {
            success = true,
            data = result,
            totalCount = _totalCount
        }) : NoContent();
    }
}