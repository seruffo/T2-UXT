using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto ItemContabilProdutoViewModel"/>
    ///</summary>
    [DataContract]
    public class ContaContabilProdutoViewModel : Base.Base
    {
        ///<summary>
        ///Codigo empresa
        ///</summary>
        [DataMember]
        public string CodigoEmpresa { get; set; }
        ///<summary>
        ///Codigo Conta
        ///</summary>
        [DataMember]
        public string CodigoConta { get; set; }
        ///<summary>
        ///Id do Produto
        ///</summary>
        [DataMember]
        public int? ProdutoId { get; set; }
        ///<summary>
        ///Data inicio vigencia
        ///</summary>
        [DataMember]
        public DateTime? Inicio { get; set; }
        ///<summary>
        ///Data fim vigencia
        ///</summary>
        [DataMember]
        public DateTime? Fim { get; set; }
        ///<summary>
        ///É assistencial?
        ///</summary>
        [DataMember]
        public char? IsAssistencial { get; set; }
        ///<summary>
        ///Classificação do grupo
        ///</summary>
        [DataMember]
        public int? GrupoClassifId { get; set; }
    }

}