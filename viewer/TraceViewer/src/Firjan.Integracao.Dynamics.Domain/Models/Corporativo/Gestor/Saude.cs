using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Saude;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class Saude : Base.Base
    {
        public TipoProcedimento TipoProcedimento { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public string TipoFicha { get; set; }
        public TipoServicoSaude TipoServicoSaude { get; set; }
        public Exame Exame { get; set; }
        public TipoResultado TipoResultado { get; set; }
        public OrigemSaude OrigemSaude { get; set; }
        public TipoOrigemServico TipoOrigemServico { get; set; }
        public Int16? ClassificacaoExameId { get; set; }
        public ClassificacaoExame ClassificacaoExame { get; set; }
        public TipoClassificacao TipoClassificacao { get; set; }
        public TipoServicoOdontologico TipoServicoOdontologico { get; set; }
        public QtdDentesEnvolvidos QtdDentesEnvolvidos { get; set; }
        public GuiaCobrancaSemPFO GuiaCobrancaSemPFO { get; set; }
        public int? GrupoClassificacaoId { get; set; }
        public GrupoClassificacao GrupoClassificacao { get; set; }
        public string CodigoServico { get; set; }
        public Estado Estado { get; set; }
        public DateTime? Fim { get; set; }
        public DateTime? Aprovacao { get; set; }
        public string CodigoFirjan { get; set; }
        public string ProcedimentoPrepartorio { get; set; }
        public MarcarHora MarcarHora { get; set; }
        public DateTime? TempoAtendimento { get; set; }
        public Quantificavel Quantificavel { get; set; }
        public bool? Autorizacao { get; set; }
        public bool? AgendaTeleatendimento { get; set; }
        public Flag DisponivelAgendamento { get; set; }
    }
}
