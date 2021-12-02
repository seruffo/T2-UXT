using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class PrimeiraVezSESI : Enums<char?>
    {
        public static PrimeiraVezSESI Sim = new PrimeiraVezSESI('S', "Sim");
        public static PrimeiraVezSESI Nao = new PrimeiraVezSESI('N', "Não");
        public PrimeiraVezSESI(char? key, string name) : base(key, name) { }
    }
}
