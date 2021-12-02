using System;
using Firjan.Integracao.Dynamics.Domain.Models.Base;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI
{
    public class Area : TipoModel<string> 
    {
        public DateTime? Fim { get; set; }
        public string CodigoDnaArea { get; set; }
    }
}