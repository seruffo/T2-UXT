using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto CodigoMunicipal"/>
    ///</summary>
    [DataContract]
    public class CodigoMunicipalViewModel : TipoViewModel<string>
    {
        [DataMember]
        public string CoodigoMunicipio { get; set; }
        [DataMember]
        public int MunicipioId { get; set; }
        [DataMember]
        public MunicipioViewModel Municipio { get; set; }
        [DataMember]
        public decimal? AliqISS { get; set; }
        [DataMember]
        public string CNAE { get; set; }
    }
}
