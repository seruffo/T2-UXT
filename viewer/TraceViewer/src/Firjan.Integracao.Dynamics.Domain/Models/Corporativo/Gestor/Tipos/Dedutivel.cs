
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class Dedutivel : Enums<char?>
    {
        public static Dedutivel Sim = new Dedutivel('S', "Sim");
        public static Dedutivel Nao = new Dedutivel('N', "Não");
        public Dedutivel(char? key, string displayName) : base(key, displayName) { }
    }
}
