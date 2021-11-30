using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC
{
    ///<summary>
    ///Objeto RegiaoUnidadeNegocio"/>
    ///</summary>
    [DataContract]
    public class RegiaoUnidadeNegocioViewModel : Base.Base
    {
        [DataMember]
        public Int16? TipoRegiaoId { get; set; }
        [DataMember]
        public TipoRegiaoViewModel TipoRegiao { get; set; }
        [DataMember]
        public int? RegiaoId { get; set; }
        [DataMember]
        public RegiaoViewModel Regiao { get; set; }
        [DataMember]
        public Int16? UnidadeNegocioId { get; set; }
        [DataMember]
        public UnidadeNegocioViewModel Unidadenegocio { get; set; }
        [DataMember]
        public DateTime? Inicio { get; set; }
        [DataMember]
        public DateTime? Fim { get; set; }
    }
}