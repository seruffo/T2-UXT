using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC
{
    [DataContract]
    public class RegiaoViewModel : TipoViewModel<int>
    {
        [DataMember]
        public short? TipoRegiaoId { get; set; }
        [DataMember]
        public TipoRegiaoViewModel TipoRegiao { get; set; }
        [DataMember]
        public int? EnderecoUnidadeId { get; set; }
        [DataMember]
        public EnderecoUnidadeViewModel EnderecoUnidade { get; set; }
    }
}