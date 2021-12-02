using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class Especialidade : Enums<char?>
    {
        public static Especialidade Sim = new Especialidade('S', "Sim");
        public static Especialidade Nao = new Especialidade('N', "Não");
        public Especialidade(char? key, string displayName) : base(key, displayName) { }
    }
}
