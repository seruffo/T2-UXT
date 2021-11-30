using Firjan.Integracao.Dynamics.Domain.Models.Base;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo
{
    public class RamoAtividade : TipoModel<Byte?>
    {
        public string Codigo { get; set; }
    }
}