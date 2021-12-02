
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto RiscoViewModel"/>
    ///</summary>
    [DataContract]
    public class RiscoViewModel : TipoViewModel<string>
    {
        [DataMember]
        public string TipoRiscoId { get; set; }
        [DataMember]
        public TipoRiscoViewModel TipoRisco { get; set; }
    }
}
