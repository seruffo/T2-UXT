using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base
{
    [DataContract]
    public abstract class TipoViewModel<T> : BaseViewModel<T>
    {
        ///<summary>
        ///Descrição da entidade.
        ///</summary>
        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Descricao { get; set; }
    }
}
