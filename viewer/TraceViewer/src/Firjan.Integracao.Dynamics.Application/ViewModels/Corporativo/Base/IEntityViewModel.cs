using System.Runtime.Serialization;
using FluentValidation.Results;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base
{
    public abstract class IModifiableEntityViewModel
    {
        ///<summary>
        ///Nome da entidade.
        ///</summary>
        [DataMember]
        public string Nome { get; set; }
    }

    public abstract class IEntityViewModel : IModifiableEntityViewModel
    {
        ///<summary>
        ///Validation result retorno
        ///</summary>
        [DataMember]
        public ValidationResult ValidationResult { get; set; }

        [DataMember]
        public object Id { get; set; }
    }

    public abstract class IEntityViewModel<T> : IEntityViewModel
    {
        ///<summary>
        ///Id da entidade.
        ///</summary>
        [DataMember]
        public new T Id { get; set; }
    }
}
