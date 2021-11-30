using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC;
using Microsoft.AspNetCore.Mvc;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class MunicipiosController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    public class MunicipiosController : Base<MunicipioViewModel,int>
    {
        public MunicipiosController(IMunicipioAppService appService) : base(appService) { }
    }
}