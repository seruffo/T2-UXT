using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class PreferenciaMedico : Enums<char?>
    {
        public static PreferenciaMedico Sim = new PreferenciaMedico('S', "Sim");
        public static PreferenciaMedico Nao = new PreferenciaMedico('N', "Não");
        public PreferenciaMedico(char? key, string name) : base(key, name) { }
    }
}
