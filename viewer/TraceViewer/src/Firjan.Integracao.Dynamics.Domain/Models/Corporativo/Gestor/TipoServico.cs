using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class TipoServico : TipoModel<char?>
    {
        public string Sigla { get; set; }
        public ObrigaArea ObrigaArea { get; set; }
        public ObrigaCusto ObrigaCusto { get; set; }        
    }
}
