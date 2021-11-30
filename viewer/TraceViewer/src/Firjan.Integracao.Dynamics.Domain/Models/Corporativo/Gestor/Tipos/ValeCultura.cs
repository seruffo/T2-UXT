
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class ValeCultura : Enums<char?>
    {
        public static ValeCultura Sim = new ValeCultura('S', "Sim");
        public static ValeCultura Nao = new ValeCultura('N', "Não");
        public ValeCultura(char? key, string displayName) : base(key, displayName) { }
    }

}
