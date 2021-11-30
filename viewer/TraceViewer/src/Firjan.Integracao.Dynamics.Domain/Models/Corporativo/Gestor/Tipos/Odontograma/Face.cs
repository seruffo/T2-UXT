using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class Face : Enums<char?>
    {
        public static Face Sim = new Face('S', "Sim");
        public Face(char? key, string name) : base(key, name) { }
    }
}
