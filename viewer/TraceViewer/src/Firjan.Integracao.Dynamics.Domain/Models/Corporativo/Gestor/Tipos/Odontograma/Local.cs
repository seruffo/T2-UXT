using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma
{
    public class Local : Enums<char?>
    {
        public static readonly Local Coroa = new Local('C',"Coroa");
        public static readonly Local Raiz = new Local('R', "Raiz");
        public static readonly Local Ambos = new Local('A', "Ambos");
        public Local(char? key, string name) : base(key, name) { }
    }
}
