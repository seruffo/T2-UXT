using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class ConsultaConsecutiva : Enums<char?>
    {
        public static ConsultaConsecutiva Sim = new ConsultaConsecutiva('S', "Sim");
        public static ConsultaConsecutiva Nao = new ConsultaConsecutiva('N', "Não");
        public ConsultaConsecutiva(char? key, string name) : base(key, name) { }
    }
}
