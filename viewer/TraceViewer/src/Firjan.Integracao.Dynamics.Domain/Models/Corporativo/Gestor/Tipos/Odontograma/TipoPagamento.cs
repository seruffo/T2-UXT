using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma
{
    public class TipoPagamento : Enums<char?>
    {
        public static readonly TipoPagamento Consulta = new TipoPagamento('1',"Consulta");
        public static readonly TipoPagamento Procedimento = new TipoPagamento('2', "Procedimento");
        public static readonly TipoPagamento Ambos = new TipoPagamento('3', "Ambos");
        public static readonly TipoPagamento NaoPaga = new TipoPagamento('4', "Nao paga");
        public static readonly TipoPagamento Faturamento = new TipoPagamento('5', "Faturamento");
        public TipoPagamento(char? key, string name) : base(key, name) { }
    }
}
