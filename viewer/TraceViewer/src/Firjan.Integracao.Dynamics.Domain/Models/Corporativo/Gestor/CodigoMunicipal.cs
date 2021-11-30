using Firjan.Integracao.Dynamics.Domain.Models.Base;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class CodigoMunicipal : TipoModel<string>
    {
        public string CoodigoMunicipio { get; set; }
        public int MunicipioId { get; set; }
        public Municipio Municipio { get; set; }
        public decimal? AliqISS { get; set; }
        public string CNAE { get; set; }
    }
}