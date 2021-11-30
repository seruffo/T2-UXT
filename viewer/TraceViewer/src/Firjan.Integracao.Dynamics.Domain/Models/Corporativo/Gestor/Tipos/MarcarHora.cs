
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class MarcarHora : Enums<char?>
    {
        public static MarcarHora Sim = new MarcarHora('S', "Sim");
        public static MarcarHora Nao = new MarcarHora('N', "Não");
        public MarcarHora(char? key, string displayName) : base(key, displayName) { }
    }

}
