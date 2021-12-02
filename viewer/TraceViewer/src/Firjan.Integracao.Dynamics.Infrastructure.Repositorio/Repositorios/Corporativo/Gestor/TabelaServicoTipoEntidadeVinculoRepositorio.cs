using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor
{
    public class TabelaServicoTipoEntidadeVinculoRepositorio : CorporativoRepositorio<TabelaServicoTipoEntidadeVinculo>, ITabelaServicoTipoEntidadeVinculoRepository
    {
        public TabelaServicoTipoEntidadeVinculoRepositorio() : base()
        {

        }

        public TabelaServicoTipoEntidadeVinculoRepositorio(CorporativoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TabelaServicoTipoEntidadeVinculo>> GetTabelasServicos(string CodigoTipoEntidadeVinculo)
        {
            ClearParameters();
            AddParameters("ch_tp_entidade_vinculo", CodigoTipoEntidadeVinculo);
            var TabelasServicosTiposEntidadesVinculos = new List<TabelaServicoTipoEntidadeVinculo>();
            var list = base.ExecuteStoredQuery("[dbo].[SPTabelaServicoTpEntCons] ").Result.ToList();
            foreach (var tabelaServicoTipoEntidade in list)
            {
                tabelaServicoTipoEntidade.GrupoClassificacaoPai = _contexto.GruposClassificacoes.FirstOrDefault(g => g.Id == tabelaServicoTipoEntidade.GrupoClassificacaoPaiId);
                tabelaServicoTipoEntidade.GrupoClassificacao = _contexto.GruposClassificacoes.FirstOrDefault(g => g.Id == tabelaServicoTipoEntidade.GrupoClassificacaoId);
                tabelaServicoTipoEntidade.TipoServico = _contexto.TiposServicos.FirstOrDefault(g => g.Id == tabelaServicoTipoEntidade.CodigoTipoServico);
                tabelaServicoTipoEntidade.Produto = _contexto.Produtos.FirstOrDefault(g => g.Id == tabelaServicoTipoEntidade.ProdutoId);
                TabelasServicosTiposEntidadesVinculos.Add(tabelaServicoTipoEntidade);
            }

            return await Task.FromResult(TabelasServicosTiposEntidadesVinculos);
        }
    }
}