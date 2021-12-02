using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma
{
    public class SituacaoAtendimento : Enums<char?>
    {
        public static readonly SituacaoAtendimento AtendimentoPendente = new SituacaoAtendimento('P',"Pendente");
        public static readonly SituacaoAtendimento AtendimentoDigitado = new SituacaoAtendimento('D', "Digitado");
        public static readonly SituacaoAtendimento FaltaBeneficiario = new SituacaoAtendimento('F', "Falta do usuário.");
        public static readonly SituacaoAtendimento FaltaColaborador = new SituacaoAtendimento('A', "Ausência (Falta) do Profissional");
        public static readonly SituacaoAtendimento Cancelado = new SituacaoAtendimento('C', "Cancelado");
        public SituacaoAtendimento(char? key, string name) : base(key, name) { }
    }
}
