using Firjan.Integracao.Dynamics.Domain.Models.Base;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.SGE
{
    public class Area : TipoModel<Int16>
    {
        public Int16 ColigadaId { get; set; }
        public Coligada Coligada { get; set; }
    }
}