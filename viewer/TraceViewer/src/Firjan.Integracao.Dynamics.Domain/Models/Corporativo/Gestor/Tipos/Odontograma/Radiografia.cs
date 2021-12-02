using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma
{
    public class Radiografia : Enums<char?>
    {
        public static Radiografia Sim = new Radiografia('S', "Sim");
        public static Radiografia Nao = new Radiografia('N', "Não");
        public Radiografia(char? key, string displayName) : base(key, displayName) { }
    }
}
