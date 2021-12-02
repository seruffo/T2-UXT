using Firjan.Integracao.Dynamics.Domain.Models.Base;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class NivelServico : TipoModel<Byte?>
    {
        public Int16? TabelaServicoId { get; set; }
        public TabelaServico TabelaServico { get; set; }
    }
}
