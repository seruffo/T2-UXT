using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Saude
{
    public class ProdutoTipoFichaRepositorio : CorporativoRepositorio<ProdutoTipoFicha>, IProdutoTipoFichaRepository
    {
        public ProdutoTipoFichaRepositorio(CorporativoContext context) : base(context) { }

        public override async Task<IEnumerable<ProdutoTipoFicha>> ComFiltros(string colunaOrdenacao, bool? asc, Expression<Func<ProdutoTipoFicha, bool>> filtro, int qtd, int pule, IEnumerable<string> includes)
        {
            return await base.ComFiltros(colunaOrdenacao, asc, filtro, qtd, pule, includes)
                .ContinueWith((g) =>
                {
                    return g.Result.Where(c => (c.Produto.Fim ?? Convert.ToDateTime("2079-06-06")) > DateTime.Now);
                });
        }

        public override Task<ProdutoTipoFicha> FirstOrDefault(Expression<Func<ProdutoTipoFicha, bool>> expression, IEnumerable<string> includes)
        {
            return base.ComFiltros(null, null, expression, 1, 0, includes)
                .ContinueWith((g) =>
                {
                    return g.Result.Where(c => (c.Produto.Fim ?? Convert.ToDateTime("2079-06-06")) > DateTime.Now).FirstOrDefault();
                });
        }
    }
}