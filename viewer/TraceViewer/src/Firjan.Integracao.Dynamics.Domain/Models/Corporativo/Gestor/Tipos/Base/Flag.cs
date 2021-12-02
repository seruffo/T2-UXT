using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base
{
    public class Flag : Enums<char?>
    {
        public static Flag Sim = new Flag('S', "Sim");
        public static Flag Nao = new Flag('N', "Não");
        public static Flag Opcional = new Flag('O', "Opcional");
        public Flag(char? key, string displayName) : base(key, displayName) { }
    }
}
