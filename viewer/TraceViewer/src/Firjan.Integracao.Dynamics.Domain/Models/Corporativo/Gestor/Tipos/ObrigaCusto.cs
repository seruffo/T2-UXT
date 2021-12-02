using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class ObrigaCusto : Enums<char?>
    {
        public static ObrigaCusto Sim = new ObrigaCusto('S', "Sim");
        public static ObrigaCusto Nao = new ObrigaCusto('N', "Não");
        public ObrigaCusto(char? key, string displayName) : base(key, displayName) { }
    }

}
