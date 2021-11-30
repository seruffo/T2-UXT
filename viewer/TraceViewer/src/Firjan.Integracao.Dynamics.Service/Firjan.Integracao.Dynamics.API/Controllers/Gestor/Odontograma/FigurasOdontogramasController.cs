using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Odontograma;
using Microsoft.AspNetCore.Mvc;

namespace Firjan.Integracao.Dynamics.API.Controllers.Gestor.Odontograma
{
    ///<Summary>
    /// Class FigurasOdontogramasController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/Gestor/Odontograma/[controller]/{version}")]
    public class FigurasOdontogramasController : Base<FiguraOdontogramaViewModel, int>
    {
        public FigurasOdontogramasController(IFiguraOdontogramaAppService appService) : base(appService) { }
    }    
}