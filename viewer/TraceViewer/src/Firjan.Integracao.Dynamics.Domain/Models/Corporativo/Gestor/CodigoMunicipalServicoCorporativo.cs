using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class CodigoMunicipalServicoCorporativo : Base.BaseClass
    {
        public int CodigoServicoOficial { get; set; }
        public string CodigoMunicipalId { get; set; }
        public CodigoMunicipal CodigoMunicipal { get; set; }
        public DateTime Inicio { get; set; }
        public string CodigoMunicipio { get; set; }
        public Municipio Municipio { get; set; }
        public DateTime? Fim { get; set; }
        public int SeqMunicipio { get; set; }
    }
}
