
using FluentValidation.Results;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base
{
    [DataContract]
    public abstract class ValidationViewModel<T>
    {
        ///<summary>
        ///Codigo da entidade.
        ///</summary>
        [DataMember]
        public T Codigo { get; set; }
        ///<summary>
        ///Descrição da entidade.
        ///</summary>
        [DataMember]
        public string Descricao { get; set; }
        ///<summary>
        ///Validation da entidade.
        ///</summary>
        [DataMember]
        public ValidationResult ValidationResult { get; set; }

        protected ValidationViewModel()
        {
            
        }
    }
}
