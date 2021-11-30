using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class CancelamentoFaixa : Enums<char?>
    {
        public static readonly CancelamentoFaixa Erro = new CancelamentoFaixa('1', "Erro de Digitação");
        public static readonly CancelamentoFaixa Cancelamento = new CancelamentoFaixa('2', "Cancelamento da Faixa");
        public CancelamentoFaixa(char? key, string name) : base(key, name) { }
    }
}
