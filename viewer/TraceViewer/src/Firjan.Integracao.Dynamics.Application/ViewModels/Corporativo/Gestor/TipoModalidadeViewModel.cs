using Firjan.Integracao.Dynamics.Application.Utils;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    [DataContract]
    public class TipoModalidadeViewModel : TipoViewModel<int>
    {
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string CodigoDN { get; set; }
        [DataMember]
        public Int16 ModalidadeId { get; set; }
        [DataMember]
        public ModalidadeViewModel Modalidade { get; set; }
        [DataMember]
        public char AcaoId { get; set; }
        [DataMember]
        public Acao Acao { get; set; }
    }
}
