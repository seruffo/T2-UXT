using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma
{
    public class SituacaoOdonto : Enums<char?>
    {
        public static readonly SituacaoOdonto AtendimentoPendente = new SituacaoOdonto('P',"Atendimento pendente");
        public static readonly SituacaoOdonto AtendimentoDigitado = new SituacaoOdonto('D', "Atendimento e odontograma digitados");
        public static readonly SituacaoOdonto FaltaBeneficiario = new SituacaoOdonto('F', "Falta do beneficiário");
        public static readonly SituacaoOdonto FaltaColaborador = new SituacaoOdonto('A', "Falta do colaborador");
        public static readonly SituacaoOdonto OdontogramaPendente = new SituacaoOdonto('O', "Atendimento digitado mas odontograma pendente");
        public static readonly SituacaoOdonto Cancelado = new SituacaoOdonto('C', "Marcacao e atendimento cancelados");
        public SituacaoOdonto(char? key, string name) : base(key, name) { }
    }
}
