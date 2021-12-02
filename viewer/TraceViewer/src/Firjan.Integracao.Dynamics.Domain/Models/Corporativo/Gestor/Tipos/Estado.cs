using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class Estado : Enums<char?>
    {
        public static Estado Estudo = new Estado('E', "Estudo");
        public static Estado Aprovado = new Estado('A', "Aprovado");
        public static Estado NaoAprovado = new Estado('N', "Não Aprovado");
        public Estado(char? key, string displayName) : base(key, displayName) { }
    }
}
