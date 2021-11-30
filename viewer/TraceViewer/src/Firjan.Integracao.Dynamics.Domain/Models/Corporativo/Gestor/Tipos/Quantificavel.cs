
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class Quantificavel : Enums<char?>
    {
        public static Quantificavel Sim = new Quantificavel('S', "Sim");
        public static Quantificavel Nao = new Quantificavel('N', "Não");
        public Quantificavel(char? key, string displayName) : base(key, displayName) { }
    }

}
