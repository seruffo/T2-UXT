using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto tipos de  fiha de saúde"/>
    ///</summary>
    [DataContract]
    public class TipoFichaViewModel : TipoViewModel<int>
    { 
        ///<summary>
        ///Atributo que indica se pode registrar valores na tabela de Histório Fisiiológico Vacinal.Assume os valores S - para sim e N - para não.
        ///</summary>
        [DataMember]
        public Flag HistFisioVac { get; set; }
        ///<summary>
        ///Atributo que indica se pode registrar valores na tabela de Histórico Familiar.Assume os valores S - para sim e N - para não.
        ///</summary>
        [DataMember]
        public Flag HistFam { get; set; }
        ///<summary>
        ///Atributo que indica se pode registrar valores na tabela de HPP de internação.Assume os valores S - para sim e N - para não.
        ///</summary>
        [DataMember]
        public Flag HppInter { get; set; }
        [DataMember]
        public Flag HppDoencas { get; set; }
        [DataMember]
        public Flag Habitos { get; set; }
        [DataMember]
        public Flag CondHab { get; set; }
        [DataMember]
        public Flag Torax { get; set; }
        [DataMember]
        public Flag Membros { get; set; }
        [DataMember]
        public Flag Coluna { get; set; }
        [DataMember]
        public Flag ExameGer { get; set; }
        [DataMember]
        public Flag Abdome { get; set; }
        [DataMember]
        public Flag Imunizacao { get; set; }
        [DataMember]
        public Flag BioComport { get; set; }
        [DataMember]
        public Flag CabecaPescoco { get; set; }
        [DataMember]
        public Flag CondTrab { get; set; }
        [DataMember]
        public Flag AcidTrab { get; set; }
        [DataMember]
        public Flag Faixa { get; set; }
        [DataMember]
        public Flag ColabResp { get; set; }
        [DataMember]
        public Flag ColabAtend { get; set; }
        [DataMember]
        public Flag QtdEspectad { get; set; }
        [DataMember]
        public Flag IndiSerie { get; set; }
        [DataMember]
        public Flag Assistencial { get; set; }
        [DataMember]
        public Flag TotAtend { get; set; }
        [DataMember]
        public Flag Evento { get; set; }
        [DataMember]
        public Flag Tema { get; set; }
        [DataMember]
        public Flag QtdAtend { get; set; }
        [DataMember]
        public Flag Entidade { get; set; }
        [DataMember]
        public Flag Pessoa { get; set; }
        [DataMember]
        public TipoUtilizacao TipoUtilizacao { get; set; }
        [DataMember]
        public Flag Umo { get; set; }
        [DataMember]
        public Flag PrimVez { get; set; }
        [DataMember]
        public Flag PrimeSpec { get; set; }
        [DataMember]
        public Flag Dente { get; set; }
        [DataMember]
        public Flag Valor { get; set; }
        [DataMember]
        public Flag QtPesAtend { get; set; }
        [DataMember]
        public Flag Turma { get; set; }
        [DataMember]
        public Flag EntPrestadora { get; set; }
        [DataMember]
        public TipoPreenchimento TipoPreenchimento { get; set; }
        [DataMember]
        public Flag PublAlvo { get; set; }
        [DataMember]
        public Flag Despesa { get; set; }
        [DataMember]
        public Flag Receita { get; set; }
        [DataMember]
        public Flag CidDeficiencia { get; set; }
        [DataMember]
        public Flag GeraAtendimento { get; set; }
    }
}