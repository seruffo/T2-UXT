using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Microsoft.AspNetCore.Mvc;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class TiposFichasController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/Gestor/[controller]/{version}")]
    public class TiposFichasController : Base<TipoFichaViewModel, int>
    {
        public TiposFichasController(ITipoFichaAppService appService) : base(appService) { }
    }
}