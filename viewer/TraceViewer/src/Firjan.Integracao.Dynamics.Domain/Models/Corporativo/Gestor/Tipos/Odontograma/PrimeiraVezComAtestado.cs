using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class PrimeiraVezComAtestado : Enums<char?>
    {
        public static PrimeiraVezComAtestado Sim = new PrimeiraVezComAtestado('S', "Sim");
        public static PrimeiraVezComAtestado Nao = new PrimeiraVezComAtestado('N', "Não");
        public PrimeiraVezComAtestado(char? key, string name) : base(key, name) { }
    }
}
