using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma
{
    public class Raiz : Enums<char?>
    {
        public static Raiz Sim = new Raiz('S', "Sim");
        public static Raiz Nao = new Raiz('N', "Não");
        public Raiz(char? key, string name) : base(key, name) { }
    }
}
