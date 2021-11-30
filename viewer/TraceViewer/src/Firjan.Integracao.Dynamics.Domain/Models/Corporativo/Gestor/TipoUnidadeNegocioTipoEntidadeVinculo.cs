using Firjan.Integracao.Dynamics.Domain.Models.Base;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class TipoUnidadeNegocioTipoEntidadeVinculo: TipoModel<Int16>
    {
        public Int16 TipoUnidadeNegocioId { get; set; }
        public TipoUnidadeNegocio TipoUnidadeNegocio { get; set; }
        public string TipoEntidadeVinculoId { get; set; }
        public TipoEntidadeVinculo TipoEntidadeVinculo { get; set; }
    }
}
