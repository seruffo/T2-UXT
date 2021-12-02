using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.STI
{
    ///<summary>
    ///Objeto Area"/>
    ///</summary>
    [DataContract]
    public class ClassificacaoServicoViewModel : TipoViewModel<int>
    {
        [DataMember]
        public int LinhaServicoId { get; set; }
        [DataMember]
        public LinhaServicoViewModel LinhaServico { get; set; }
        [DataMember]
        public string AreaDN { get; set; }
    }
}