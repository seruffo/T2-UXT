using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.SGE
{
    public class AreaDNViewModel : TipoViewModel<int>
    {
        [DataMember]
        public DateTime? Inicio { get; set; }
        [DataMember]
        public DateTime? Fim { get; set; }
    }
}