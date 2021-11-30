using Microsoft.AspNetCore.Mvc;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.API.Base.CRUD;
using System;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.SRC;

namespace Firjan.Integracao.Dynamics.API.Controllers
{
    ///<Summary>
    /// Class UnidadesNegociosController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/Gestor/[controller]/{version}")]
    public class UnidadesNegociosController : Base<UnidadeNegocioViewModel, Int16>
    {
        public UnidadesNegociosController(IUnidadeNegocioAppService appService) : base(appService) { }
    }
}