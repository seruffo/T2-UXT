using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class Provisorio : Enums<char?>
    {
        public static Provisorio Sim = new Provisorio('S', "Sim");
        public static Provisorio Nao = new Provisorio('N', "Não");
        public Provisorio(char? key, string name) : base(key, name) { }
    }
}
