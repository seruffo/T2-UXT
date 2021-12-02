using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.STI
{
    [DataContract]
    public class FuncaoViewModel : TipoViewModel<string>
    {
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Sigla { get; set; }
        [DataMember]
        public bool ParticipantePF { get; set; }
        [DataMember]
        public bool ParticipantePJ { get; set; }
        [DataMember]
        public bool ValidaFavorecidoContratoPF { get; set; }
        [DataMember]
        public DateTime Inicio { get; set; }
        [DataMember]
        public DateTime Fim { get; set; }
    }
}