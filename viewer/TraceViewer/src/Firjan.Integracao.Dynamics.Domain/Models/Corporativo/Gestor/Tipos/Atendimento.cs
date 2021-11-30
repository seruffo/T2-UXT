
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class Atendimento : Enums<char>
    {
        public static Atendimento Sim = new Atendimento('S', "Sim");
        public static Atendimento Nao = new Atendimento('N', "Não");
        public Atendimento(char key, string displayName) : base(key, displayName) { }
    }
}
