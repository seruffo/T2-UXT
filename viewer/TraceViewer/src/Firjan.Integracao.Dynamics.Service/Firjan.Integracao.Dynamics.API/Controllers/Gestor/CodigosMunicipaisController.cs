using Microsoft.AspNetCore.Mvc;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.API.Base.CRUD;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class CodigosMunicipaisController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/Gestor/[controller]/{version}")]
    public class CodigosMunicipaisController : Base<CodigoMunicipalViewModel, string>
    {
        ///<Summary>
        /// Constructor CodigosMunicipaisController
        ///</Summary>
        public CodigosMunicipaisController(ICodigoMunicipalAppService AppService) : base(AppService) { }
    }
}