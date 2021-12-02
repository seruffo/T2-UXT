using Firjan.Integracao.Dynamics.Domain.Models.Base;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.SGE
{
    public class AreaDN : TipoModel<Int32>
    {
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }
    }
}