using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor
{
    public class ClassificacaoRepositorio : CorporativoRepositorio<Classificacao>, IClassificacaoRepository
    {
        public ClassificacaoRepositorio() : base() { }

        public ClassificacaoRepositorio(CorporativoContext context) : base(context) { }

        public async Task<IEnumerable<Classificacao>> GetTabelasServicos(string CodigoTipoServicoOficial, string CodigoTipoEntidadeVinculo)
        {
            ClearParameters();
            AddParameters("ch_ql_servoficial_grupoclassif", CodigoTipoServicoOficial);
            AddParameters("ch_tp_entidade_vinculo", CodigoTipoEntidadeVinculo);
            var Classificacoes = new List<Classificacao>();
            await base.ExecuteStoredQuery("[dbo].[SPConsultarSubTipoPorAreaNegocio] ")
                .Result.ForEachAsync(4, body: async classificacao => 
                {
                    classificacao.GrupoClassificacao = _contexto.GruposClassificacoes.FirstOrDefault(g => g.Id == classificacao.GrupoClassificacaoId);
                    classificacao.Produto = _contexto.Produtos.FirstOrDefault(p => p.Id == classificacao.ProdutoId);
                    Classificacoes.Add(classificacao);
                });

            return Classificacoes;
        }
    }
}