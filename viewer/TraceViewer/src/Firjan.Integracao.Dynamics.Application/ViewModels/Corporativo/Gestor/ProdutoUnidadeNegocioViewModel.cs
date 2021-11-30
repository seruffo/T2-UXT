using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using ServiceStack;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto tipos de  fiha de saúde"/>
    ///</summary>
    [DataContract]
    public class ProdutoUnidadeNegocioViewModel : TipoViewModel<int>
    {
        ///<summary>
        ///Data de início da oferta do serviço pela unidade de negócios.
        ///</summary>
        [DataMember]
        public DateTime? Inicio { get; set; }
        ///<summary>
        ///Id do produto da oferta do serviço pela unidade de negócios.
        ///</summary>
        [DataMember]
        public int ProdutoId { get; set; }
        ///<summary>
        ///Produto da oferta do serviço pela unidade de negócios.
        ///</summary>
        [DataMember]
        [ApiMember(ParameterType = "model")]
        public ProdutoViewModel Produto { get; set; }
        ///<summary>
        ///Data de fim da oferta do serviço pela unidade de negócios.
        ///</summary>
        [DataMember]
        public DateTime? Fim { get; set; }
        ///<summary>
        ///Id do produto da oferta do serviço pela unidade de negócios.
        ///</summary>
        [DataMember]
        public Int16 UnidadeNegocioId { get; set; }
        ///<summary>
        ///Unidade de negócio do produto unidade de negócio.
        ///</summary>
        [DataMember]
        [ApiMember(ParameterType = "model")]
        public UnidadeNegocioViewModel UnidadeNegocio { get; set; }

        [DataMember]
        public char ExecutaServicoOferecido { get; set; }
    }
}