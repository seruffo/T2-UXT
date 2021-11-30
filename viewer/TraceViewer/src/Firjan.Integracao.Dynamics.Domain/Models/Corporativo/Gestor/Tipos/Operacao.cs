using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class Operacao : Enums<char?>
    {
        public static readonly Operacao Identificado = new Operacao('I',"Identificado");
        public static readonly Operacao Planejado = new Operacao('P', "Planejado no SESI");
        public static readonly Operacao Realizado = new Operacao('R', "Realizado no SESI");
        public Operacao(char? key, string name) : base(key, name) { }
    }
}
