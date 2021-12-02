
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class ObrigaArea : Enums<char?>
    {
        public static ObrigaArea Sim = new ObrigaArea('S', "Sim");
        public static ObrigaArea Nao = new ObrigaArea('N', "Não");
        public ObrigaArea(char? key, string displayName) : base(key, displayName) { }
    }

}
