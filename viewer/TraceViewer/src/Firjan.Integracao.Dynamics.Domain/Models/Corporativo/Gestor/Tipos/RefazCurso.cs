
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class RefazCurso : Enums<char?>
    {
        public static RefazCurso Sim = new RefazCurso('S', "Sim");
        public static RefazCurso Nao = new RefazCurso('N', "Não");
        public RefazCurso(char? key, string displayName) : base(key, displayName) { }
    }

}
