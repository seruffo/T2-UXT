using Firjan.Integracao.Dynamics.Domain.Models.Base;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class Genero : TipoModel<string>
    {
        public Byte? RamoAtividadeId { get; set; }
        public RamoAtividade RamoAtividade { get; set; }
    }
}