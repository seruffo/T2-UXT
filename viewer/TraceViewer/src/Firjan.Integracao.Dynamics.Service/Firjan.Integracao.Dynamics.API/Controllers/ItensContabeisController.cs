using Microsoft.AspNetCore.Mvc;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.API.Base.Query;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class ItensContabeisController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    public class ItensContabeisController : Base<ItemContabilViewModel, string>
    {
        public ItensContabeisController(IItemContabilAppService appService) : base(appService) { }
    }
}