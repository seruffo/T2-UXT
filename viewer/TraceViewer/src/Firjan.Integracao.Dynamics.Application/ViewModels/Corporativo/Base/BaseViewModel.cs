using FluentValidation.Results;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base
{
    [DataContract]
    public abstract class Base
    {
        ///<summary>
        ///Validation result retorno
        ///</summary>
        [DataMember]
        public ValidationResult ValidationResult { get; set; }
        protected Base() {}
    }

    [DataContract]
    public abstract class BaseViewModel<T> : Base
    {
        ///<summary>
        ///Id da entidade.
        ///</summary>
        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Id { get; set; }

    }
}
