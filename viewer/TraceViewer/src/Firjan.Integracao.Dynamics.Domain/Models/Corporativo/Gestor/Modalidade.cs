
using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class Modalidade  : TipoModel<Int16?>
    {
        public TipoEntidade TipoEntidade { get; set; }
        public DateTime Fim { get; set; }
    }
}
