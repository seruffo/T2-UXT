
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class UnidadeVinculada : Enums<char?>
    {
        public static UnidadeVinculada Sim = new UnidadeVinculada('S', "Sim");
        public static UnidadeVinculada Nao = new UnidadeVinculada('N', "Não");
        public UnidadeVinculada(char? key, string displayName) : base(key, displayName) { }
    }

}
