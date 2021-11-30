using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo
{
    public class CodigoMunicipalProduto
    {
        public DateTime Inicio { get; set; }
        public CodigoMunicipal CodigoMunicipal { get; set; }
        public Municipio Municipio { get; set; }
        public DateTime Fim { get; set; }
    }
}
