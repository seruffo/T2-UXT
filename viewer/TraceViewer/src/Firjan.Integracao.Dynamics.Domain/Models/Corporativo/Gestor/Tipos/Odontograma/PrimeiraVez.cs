using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class PrimeiraVez : Enums<char?>
    {
        public static PrimeiraVez Sim = new PrimeiraVez('S', "Sim");
        public static PrimeiraVez Nao = new PrimeiraVez('N', "Não");
        public PrimeiraVez(char? key, string name) : base(key, name) { }
    }
}
