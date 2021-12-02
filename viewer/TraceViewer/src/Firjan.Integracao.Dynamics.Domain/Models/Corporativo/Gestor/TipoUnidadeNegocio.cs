using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class TipoUnidadeNegocio:  TipoModel<Int16>
    {
        public string Sigla { get; set; }
        public UnidadeVinculada UnidadeVinculada { get; set; }
    }
}
