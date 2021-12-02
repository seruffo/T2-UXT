using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class OrigemSaude : Enums<char?>
    {
        public static OrigemSaude MeioAmbiente = new OrigemSaude('A', "Assistencial");
        public static OrigemSaude AssistenciaSocial = new OrigemSaude('O', "Ocupacional");
        public static OrigemSaude Ambos = new OrigemSaude('B', "Ambos");
        public OrigemSaude(char? key, string displayName) : base(key, displayName) { }
    }
}
