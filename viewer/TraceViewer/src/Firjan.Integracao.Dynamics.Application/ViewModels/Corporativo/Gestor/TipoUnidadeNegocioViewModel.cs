using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto TipoUnidadeNegocioViewModel"/>
    ///</summary>
    [DataContract]
    public class TipoUnidadeNegocioViewModel : TipoViewModel<Int16>
    {
        [DataMember]
        public string Sigla { get; set; }
        [DataMember]
        public UnidadeVinculada UnidadeVinculada { get; set; }
    }
}
