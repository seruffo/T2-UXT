using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto Codigo Municipal Serviço Corpoativo"/>
    ///</summary>
    [DataContract]
    public class CodigoMunicipalServicoCorporativoViewModel : Base.Base
    {
        [DataMember]
        public int CodigoServicoOficial { get; set; }
        [DataMember]
        public string CodigoMunicipalId { get; set; }
        [DataMember]
        public CodigoMunicipalViewModel CodigoMunicipal { get; set; }
        [DataMember]
        public DateTime Inicio { get; set; }
        [DataMember]
        public string CodigoMunicipio { get; set; }
        [DataMember]
        public MunicipioViewModel Municipio { get; set; }
        [DataMember]
        public DateTime Fim { get; set; }
        [DataMember]
        public int SeqMunicipio { get; set; }
    }
}
