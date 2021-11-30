using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.STI;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.STI;
using Microsoft.AspNetCore.Mvc;
using Firjan.Integracao.Dynamics.API.Base.Query;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class LinhasServicosController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/STI/[controller]/{version}")]
    public class LinhasServicosController : Base<LinhaServicoViewModel, int>
    {
        public LinhasServicosController(ILinhaServicoAppService appService) : base(appService) { }
    }
}