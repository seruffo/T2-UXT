using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Domain.Models.SGE;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.SGE
{
    public class AreaSGEViewModel : TipoViewModel<Int16>
    {
        ///<summary>
        ///Código coligada.
        ///</summary>
        [DataMember]
        public Int16 ColigadaId { get; set; }
        ///<summary>
        ///Objeto coligada
        ///</summary>
        [DataMember]
        public ColigadaViewModel Coligada { get; set; }
    }
}