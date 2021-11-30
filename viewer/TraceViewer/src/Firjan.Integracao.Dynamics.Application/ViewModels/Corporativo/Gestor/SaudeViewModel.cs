using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto saúde view"/>
    ///</summary>
    [DataContract]
    public class SaudeViewModel : Base.Base
    {
        [DataMember]
        public TipoProcedimento TipoProcedimento { get; set; }
        [DataMember]
        public int ProdutoId { get; set; }
        [DataMember]
        public ProdutoViewModel Produto { get; set; }
        [DataMember]
        public TipoServicoSaude TipoServicoSaude { get; set; }
        [DataMember]
        public Exame Exame { get; set; }
        [DataMember]
        public TipoResultado TipoResultado { get; set; }
        [DataMember]
        public OrigemSaude OrigemSaude { get; set; }
        [DataMember]
        public TipoOrigemServico TipoOrigemServico { get; set; }
        [DataMember]
        public Int16? ClassificacaoExameId { get; set; }
        [DataMember]
        public ClassificacaoExameViewModel ClassificacaoExame { get; set; }
        [DataMember]
        public TipoClassificacao TipoClassificacao { get; set; }
        [DataMember]
        public TipoServicoOdontologico TipoServicoOdontologico { get; set; }
        [DataMember]
        public QtdDentesEnvolvidos QtdDentesEnvolvidos { get; set; }
        [DataMember]
        public GuiaCobrancaSemPFO GuiaCobrancaSemPFO { get; set; }
        [DataMember]
        public int? GrupoClassificacaoId { get; set; }
        [DataMember]
        public GrupoClassificacaoViewModel GrupoClassificacao { get; set; }
        [DataMember]
        public string CodigoServico { get; set; }
        [DataMember]
        public Estado Estado { get; set; }
        [DataMember]
        public DateTime? Fim { get; set; }
        [DataMember]
        public DateTime? Aprovacao { get; set; }
        [DataMember]
        public string CodigoFirjan { get; set; }
        [DataMember]
        public string ProcedimentoPrepartorio { get; set; }
        [DataMember]
        public MarcarHora MarcarHora { get; set; }
        [DataMember]
        public DateTime? TempoAtendimento { get; set; }
        [DataMember]
        public Quantificavel Quantificavel { get; set; }
        [DataMember]
        public bool? Autorizacao { get; set; }
        [DataMember]
        public bool? AgendaTeleatendimento { get; set; }
        [DataMember]
        public Flag DisponivelAgendamento { get; set; }
        [DataMember]
        public string TipoFicha { get; set; }
        [DataMember]
        public List<SaudeFiguraOdontograma> SaudeFiguraOdontograma { get; set; }

    }
}
