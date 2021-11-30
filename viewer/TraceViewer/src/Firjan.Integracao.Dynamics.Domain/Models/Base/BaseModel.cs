using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firjan.Integracao.Dynamics.Domain.Models.Base
{
    public abstract class BaseClass
    {
        ///<summary>
        ///Validation result retorno
        ///</summary>
        public ValidationResult ValidationResult { get; set; }

        protected BaseClass() { }
    }

    public abstract class Base : BaseClass
    {
        public string Descricao { get; set; }

        protected Base() { }
    }

    public abstract class BaseModel<T> : Base
    {
        [NotMapped]
        public bool? IsIdentity { get; set; } = true;

        public T Id { get; set; }

        protected BaseModel() { }
    }
}
