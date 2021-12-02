using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class MarcadoAtendimento : Enums<char?>
    {
        public static MarcadoAtendimento Sim = new MarcadoAtendimento('S', "Sim");
        public static MarcadoAtendimento Nao = new MarcadoAtendimento('N', "Não");
        public MarcadoAtendimento(char? key, string name) : base(key, name) { }
    }
}
