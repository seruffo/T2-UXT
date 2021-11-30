using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class Assistencial : Enums<char?>
    {
        public static Assistencial Sim = new Assistencial('S', "Sim");
        public static Assistencial Nao = new Assistencial('N', "Não");
        public Assistencial(char? key, string name) : base(key, name) { }
    }
}
