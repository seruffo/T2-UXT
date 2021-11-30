using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto Area"/>
    ///</summary>
    [DataContract]
    public class TipoUnidadeNegocioTipoEntidadevinculoViewModel : TipoViewModel<Int16>
    {
        ///<summary>
        ///Id do Tipo Unidade Negocio
        ///</summary>
        [DataMember]
        public Int16 TipoUnidadeNegocioId { get; set; }
        ///<summary>
        ///Tipo Unidade Negocio
        ///</summary>
        [DataMember]
        public TipoUnidadeNegocioViewModel TipoUnidadeNegocio { get; set; }
        ///<summary>
        ///Id do Tipo Entidade Vinculo
        ///</summary
        [DataMember]
        public string TipoEntidadeVinculoId { get; set; }
        ///<summary>
        ///Tipo Entidade Vinculo
        ///</summary
        [DataMember]
        public TipoEntidadeVinculoViewModel TipoEntidadeVinculo { get; set; }


    }
}