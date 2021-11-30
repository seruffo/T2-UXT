using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TodasPessoas : Enums<char?>
    {
        public static TodasPessoas Sim = new TodasPessoas('S', "Sim");
        public static TodasPessoas Nao = new TodasPessoas('N', "Não");
        public TodasPessoas(char? key, string displayName) : base(key, displayName) { }
    }
}
