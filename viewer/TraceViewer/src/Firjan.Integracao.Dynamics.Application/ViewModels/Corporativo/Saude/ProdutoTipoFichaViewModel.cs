using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Saude
{
    ///<summary>
    ///Objeto produto tipos de  fiha de saúde"/>
    ///</summary>
    [DataContract]
    public class ProdutoTipoFichaViewModel : Base.Base
    {
        ///<summary>
        ///Sequencial do produto
        ///</summary>
        [DataMember]
        public int ProdutoId { get; set; }
        ///<summary>
        ///Objecto Produto
        ///</summary>
        [DataMember]
        public ProdutoViewModel Produto { get; set; }
        ///<summary>
        ///Sequencial do servico
        ///</summary>
        [DataMember]
        public int ServicoId { get; set; }
        ///<summary>
        ///Objeto servico
        ///</summary>
        [DataMember]
        public ServicoViewModel Servico { get; set; }
        ///<summary>
        ///Código sequencial do tipo reistro de atendimento
        ///</summary>
        [DataMember]
        public int TipoFichaId { get; set; }
        ///<summary>
        ///Objeto tipo reistro de atendimento
        ///</summary>
        [DataMember]
        public TipoFichaViewModel TipoFicha { get; set; }
        ///<summary>
        ///<summary>
        ///Serviços relacionados a mais de uma ficha, o flag indica qual ficha deve ser gerado no momento do atendimento
        ///</summary>
        [DataMember]
        public Flag GeraAtendimento { get; set; }

    }
}