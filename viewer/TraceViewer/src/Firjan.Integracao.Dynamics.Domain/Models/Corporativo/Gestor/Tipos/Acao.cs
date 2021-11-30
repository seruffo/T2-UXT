using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class Acao : Enumeration
    {
        public static readonly Acao Direta = new Acao('D', "Direta");
        public static readonly Acao Indireta = new Acao('I', "Indireta");
        public Acao(char? key, string displayName) : base(key, displayName) { }
    }
}
