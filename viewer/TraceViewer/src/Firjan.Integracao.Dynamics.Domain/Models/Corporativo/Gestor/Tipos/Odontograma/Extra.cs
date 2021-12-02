using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class Extra : Enums<char?>
    {
        public static Extra Sim = new Extra('S', "Sim");
        public static Extra Nao = new Extra('N', "Não");
        public Extra(char? key, string name) : base(key, name) { }
    }
}
