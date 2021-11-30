using Microsoft.AspNetCore.Mvc;
using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.API.Controllers.Gestor
{
    ///<Summary>
    /// Class EntidadesController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/SRC/[controller]/{version}")]
    public class EntidadesController : Base<EmpresaViewModel,string>
    {
        ///<Summary>
        /// Constructor EntidadesController
        ///</Summary>
        public EntidadesController(IEmpresaAppService AppService) : base(AppService) { }
    }    
} 