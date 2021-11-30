using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor 
{
    [DataContract]
    public class TUSSViewModel : TipoViewModel<int>
    {
        [DataMember]
        public string Codigo { get; set; }
    }
}
