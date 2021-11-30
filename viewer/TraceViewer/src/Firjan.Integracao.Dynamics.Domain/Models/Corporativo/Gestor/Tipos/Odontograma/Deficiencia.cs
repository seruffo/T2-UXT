using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma
{
    public class Deficiencia : Enums<char?>
    {
        public static Deficiencia Sim = new Deficiencia('S', "Sim");
        public static Deficiencia Nao = new Deficiencia('N', "Não");
        public Deficiencia(char? key, string displayName) : base(key, displayName) { }
    }
}
