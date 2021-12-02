using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    [DataContract]
    public class ModalidadeViewModel : TipoViewModel<Int16?>
    {
        [DataMember]
        public TipoEntidade TipoEntidade { get; set; }
        [DataMember]
        public DateTime Fim { get; set; }
    }
}
