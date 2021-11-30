
using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma
{
    public class Marcacao : TipoModel<int>
    {
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public Operacao Operacao { get; set; }
        public Byte NumeroDente { get; set; }
        public int? FiguraOdontogramaId { get; set; }
        public FiguraOdontograma FiguraOdontograma { get; set; }
        public string NumeroTelefone { get; set; }
        public string NomePessoa { get; set; }
        public DateTime Pagamento { get; set; }
        public string MotivoCancelamento { get; set; }
        public DateTime Cancelamento { get; set; }
        public DateTime Expira { get; set; }
        public Provisorio Provisorio { get; set; }
        public Extra Extra { get; set; }
        public PreferenciaMedico PreferenciaMedico { get; set; }
        public TipoConsulta TipoConsulta { get; set; }
        public DateTime Data { get; set; }
        public TipoAtendimentoMarcacao TipoAtendimento { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public PrimeiraVez PrimeiraVez { get; set; }
        public Assistencial Assistencial { get; set; }
        public string AtendimentoId { get; set; }
        public Atendimento Atendimento { get; set; }
        public PrimeiraVezComAtestado PrimeiraVezComAtestado { get; set; }
        public PrimeiraVezSESI PrimeiraVezSESI { get; set; }
        public ConsultaConsecutiva ConsultaConsecutiva { get; set; }
    }
}
