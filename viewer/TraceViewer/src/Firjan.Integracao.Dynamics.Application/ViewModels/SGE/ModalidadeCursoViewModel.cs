using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Domain.Models.SGE;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.SGE
{
    public class ModalidadeCursoViewModel: TipoViewModel<string>
    {
        ///<summary>
        ///Código coligada.
        ///</summary>
        [DataMember]
        public Int16 ColigadaId { get; set; }
        ///<summary>
        ///Objecto coligada.
        ///</summary>
        [DataMember]
        public Coligada Coligada { get; set; }
    }
}