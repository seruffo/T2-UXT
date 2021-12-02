using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto TabelaReferencia"/>
    ///</summary>
    [DataContract]
    public class TabelaReferenciaViewModel : TipoViewModel<int?>
    {
        [DataMember]
        public Abrangencia Abrangencia { get; set; }
        [DataMember]
        public int? ProdutoId { get; set; }
        [DataMember]
        public ProdutoViewModel Produto { get; set; }
        [DataMember]
        public int? GrupoClassificacaoId { get; set; }
        [DataMember]
        public GrupoClassificacaoViewModel GrupoClassificacao { get; set; }
        [DataMember]
        public TipoPessoa TipoCliente { get; set; }
        [DataMember]
        public TipoRegimento TipoRegimento { get; set; }
        [DataMember]
        public DateTime? Data { get; set; }
        [DataMember]
        public DateTime? DataAprovacao { get; set; }
        [DataMember]
        public Int16? UnidadeNegocioId { get; set; }
        [DataMember]
        public UnidadeNegocioViewModel UnidadeNegocio { get; set; }
    }
}
