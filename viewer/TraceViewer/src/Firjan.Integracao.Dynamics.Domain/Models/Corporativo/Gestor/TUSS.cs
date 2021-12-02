using Firjan.Integracao.Dynamics.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor 
{
    public class TUSS : TipoModel<int>
    {
        public string Codigo { get; set; }
    }
}
