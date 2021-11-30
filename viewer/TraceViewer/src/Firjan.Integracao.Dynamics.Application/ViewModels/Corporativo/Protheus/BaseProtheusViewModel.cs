using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using FluentValidation.Results;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Protheus
{
    public class BaseProtheusViewModel<T> : TipoViewModel<T>
    {
        ///<summary>
        ///Data início
        ///</summary>
        [DataMember]
        public DateTime? Inicio { get; set; }
        ///<summary>
        ///Data fim
        ///</summary>
        [DataMember]
        public DateTime? Fim { get; set; }
        ///<summary>
        ///Empresa
        ///</summary>
        [DataMember]
        public string Empresa { get; set; }
    }

}
