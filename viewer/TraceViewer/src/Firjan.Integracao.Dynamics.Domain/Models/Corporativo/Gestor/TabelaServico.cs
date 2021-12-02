using Firjan.Integracao.Dynamics.Domain.Models.Base;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class TabelaServico : TipoModel<Int16?>
    {
        public string CodigoTipoEntidadeVinculo { get; set; }
        public TipoEntidadeVinculo TipoEntidadeVinculo { get; set; }
        public char? IsAtendimento { get; set; }
        public char? TipoPreco { get; set; }
    }
}
