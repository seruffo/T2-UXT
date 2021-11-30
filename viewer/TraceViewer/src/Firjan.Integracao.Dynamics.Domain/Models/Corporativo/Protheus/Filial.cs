using Firjan.Integracao.Dynamics.Domain.Models.Base;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus
{
    public class Filial : TipoModel<string>
    {
        public string Empresa { get; set; }
    }
}