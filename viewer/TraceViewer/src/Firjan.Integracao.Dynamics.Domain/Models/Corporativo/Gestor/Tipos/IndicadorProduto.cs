
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class IndicadorProduto : Enums<char?>
    {
        public static IndicadorProduto Sim = new IndicadorProduto('S', "Sim");
        public static IndicadorProduto Nao = new IndicadorProduto('N', "Não");
        public IndicadorProduto(char? key, string displayName) : base(key, displayName) { }
    }

}
