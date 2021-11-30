using Firjan.Integracao.Dynamics.API.Base.CRUD;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Firjan.Integracao.Dynamics.API.Controllers.Gestor
{
    ///<Summary>
    /// Class TiposUnidadesNegociosTiposEntidadesController
    ///</Summary>
    [ApiVersion("1")]
    [Route("api/Gestor/[controller]/{version}")]
    public class TiposEntidadesTiposUnidadesNegociosController : Base<TipoUnidadeNegocioTipoEntidadevinculoViewModel, Int16>
    {
        public TiposEntidadesTiposUnidadesNegociosController(ITipoUnidadeNegocioTipoEntidadeVinculoAppService appService) : base(appService) { }
    }    
}