using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma
{
    public class Obrigatorio : Enums<char?>
    {
        public static Obrigatorio Sim = new Obrigatorio('S', "Sim");
        public static Obrigatorio Nao = new Obrigatorio('N', "Não");
        public Obrigatorio(char? key, string displayName) : base(key, displayName) { }
    }
}
