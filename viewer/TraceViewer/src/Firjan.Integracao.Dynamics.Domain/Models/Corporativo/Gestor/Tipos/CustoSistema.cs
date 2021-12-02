
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class CustoSistema : Enums<char?>
    {
        public static CustoSistema Sim = new CustoSistema('S', "Sim");
        public static CustoSistema Nao = new CustoSistema('N', "Não");
        public CustoSistema(char? key, string displayName) : base(key, displayName) { }
    }
}
