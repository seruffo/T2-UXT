using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC
{
    public class Bairro : TipoModel<int>
    {
        public int MunicipioId { get; set; }
        public Municipio Municipio { get; set; }
        public string CodigoLocalCorreio { get; set; }
        public string CodigoBairroCorreio { get; set; }
        public char? Ativo { get; set; }
        public string DescricaoAbreviada { get; set; }
    }
}
