
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class Divulgado : Enums<char?>
    {
        public static Divulgado Sim = new Divulgado('S', "Sim");
        public static Divulgado Nao = new Divulgado('N', "Não");
        public Divulgado(char? key, string displayName) : base(key, displayName) { }
    }

}
