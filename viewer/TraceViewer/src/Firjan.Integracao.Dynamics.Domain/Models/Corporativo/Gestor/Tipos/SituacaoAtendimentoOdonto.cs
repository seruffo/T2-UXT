using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma
{
    public class SituacaoAtendimentoOdonto : Enums<char?>
    {
        public static readonly SituacaoAtendimentoOdonto AtendimentoPendente = new SituacaoAtendimentoOdonto('P', "Atendimento pendente");
        public static readonly SituacaoAtendimentoOdonto AtendimentoDigitado = new SituacaoAtendimentoOdonto('D', "Atendimento e odontograma digitados");
        public static readonly SituacaoAtendimentoOdonto FaltaBeneficiario = new SituacaoAtendimentoOdonto('F', "Falta do beneficiário");
        public static readonly SituacaoAtendimentoOdonto FaltaColaborador = new SituacaoAtendimentoOdonto('A', "Falta do colaborador");
        public static readonly SituacaoAtendimentoOdonto OdontogramaPendente = new SituacaoAtendimentoOdonto('O', "Atendimento digitado mas odontograma pendente");
        public static readonly SituacaoAtendimentoOdonto Cancelado = new SituacaoAtendimentoOdonto('C', "Marcacao e atendimento cancelados");
        public SituacaoAtendimentoOdonto(char? key, string name) : base(key, name) { }
    }
}
