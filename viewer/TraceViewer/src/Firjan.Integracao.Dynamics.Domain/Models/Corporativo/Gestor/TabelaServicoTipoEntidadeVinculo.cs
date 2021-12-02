using Firjan.Integracao.Dynamics.Domain.Models.Base;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class TabelaServicoTipoEntidadeVinculo : TipoModel<Int16?>
    {
        public char CodigoTipoServico { get; set; }
        public TipoServico TipoServico { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int GrupoClassificacaoId { get; set; }
        public GrupoClassificacao GrupoClassificacao { get; set; }
        public int GrupoClassificacaoPaiId { get; set; }
        public GrupoClassificacao GrupoClassificacaoPai { get; set; }
    }
}
