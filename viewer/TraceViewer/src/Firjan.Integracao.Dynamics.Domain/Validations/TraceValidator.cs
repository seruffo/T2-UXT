#region Trace
using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models;
#endregion

namespace Firjan.Integracao.Dynamics.Domain.Validations
{
    public class TraceValidator : AbstractValidator<Trace>
    {
        public TraceValidator() { }
    }
}