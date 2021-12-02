using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.STI
{
    public class ClassificacaoServicoRepositorio : CorporativoRepositorio<ClassificacaoServico>, IClassificacaoServicoRepository
    {
        public ClassificacaoServicoRepositorio(CorporativoContext context) : base(context) { }

        public override async Task<ClassificacaoServico> FirstOrDefault(Expression<Func<ClassificacaoServico, bool>> expression, IEnumerable<string> includes)
        {
            return await base.FirstOrDefault(expression, includes).ContinueWith((ClassificacaoServico) => { return Bind(ClassificacaoServico.Result).Result; });
        }

        public override async Task<IEnumerable<ClassificacaoServico>> ComFiltros(string colunaOrdenacao, bool? asc, Expression<Func<ClassificacaoServico, bool>> filtro, int qtd, int pule, IEnumerable<string> includes)
        {
            return await base.ComFiltros(colunaOrdenacao, asc, filtro, qtd, pule, includes)
                .ContinueWith((ClassificacoesServicos) => { return ClassificacoesServicos.Result.ForEach(async n => await Bind(n)).AsParallel(); });
        }

        public async Task<ClassificacaoServico> Bind(ClassificacaoServico result)
        {
            if (result != null)
            {
                result.LinhaServico = _contexto
                    .LinhasServicos
                    .Include(b => b.Funcao)
                    .FirstOrDefault(g => g.Id == result.Id);
            }

            return await Task.FromResult(result);
        }
    }
}