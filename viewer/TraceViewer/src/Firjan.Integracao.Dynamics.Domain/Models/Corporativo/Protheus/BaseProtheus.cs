using FluentValidation.Results;
using Firjan.Integracao.Dynamics.Domain.Models.Base;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus
{
    public class BaseProtheus<T> : TipoModel<T>
    {
        public string Empresa { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }
    }
}
