using Microsoft.AspNetCore.Mvc;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly Application.Interfaces.ILoginAppService _loginAppService;

        public LoginsController(Application.Interfaces.ILoginAppService loginAppService) => _loginAppService = loginAppService;

        [HttpPost]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public object Post([FromBody] Domain.Models.User user)
        {
            return user == null ? BadRequest() : _loginAppService.FindByLogin(user);
        }
    }
}