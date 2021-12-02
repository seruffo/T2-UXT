using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.SGE;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Results;
using System.Data.SqlClient;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor
{
    public class ProdutoRepositorio : CorporativoRepositorio<Produto>, IProdutoRepository
    {
        public ProdutoRepositorio() : base() { }

        public ProdutoRepositorio(CorporativoContext context, SGEContext sgeContexto) : base(context, sgeContexto) { }

        public override async Task<Produto> FirstOrDefault(Expression<Func<Produto, bool>> expression, IEnumerable<string> includes)
        {
            return await base.FirstOrDefault(expression, includes).ContinueWith((produto) => { return BindProduto(produto.Result).Result; });
        }

        public override async Task<IEnumerable<Produto>> ComFiltros(string colunaOrdenacao, bool? asc, Expression<Func<Produto, bool>> filtro, int qtd, int pule, IEnumerable<string> includes)
        {
            return await base.ComFiltros(colunaOrdenacao, asc, filtro, qtd, pule, includes)
                .ContinueWith((produtos) => { return produtos.Result.ForEach(async n => await BindProduto(n)).AsParallel(); });
        }

        public async Task<Produto> BindProduto(Produto result)
        {
            if (result != null)
            {
                if (!String.IsNullOrEmpty(result.CodigoAreaDN))
                    result.AreaDN = _contexto
                        .AreasDNs
                        .FirstOrDefault(t => t.Id == Convert.ToInt32(result.CodigoAreaDN));

                result.Lazer = _contexto
                    .Lazeres
                    .Include(b => b.Produto)
                    .FirstOrDefault(g => g.Id == result.Id);

                result.Saude = _contexto
                    .Saudes
                    .FirstOrDefault(g => g.ProdutoId == result.Id);

                if (result.ModalidadeId.HasValue)
                    result.Modalidade = _SGEContexto
                    .ModalidadesCursos
                    .FirstOrDefault(g => g.Id == result.ModalidadeId.ToString());
            }

            return await Task.FromResult(result);
        }

        public override Task<Produto> Atualizar(Produto item)
        {
            AddParameters("in_sq_classifservofic", item.Id.GetDBNullOrValue());
            AddParameters("vc_ds_servoficial_classif", item.Descricao.GetDBNullOrValue());
            AddParameters("ch_fg_atendimento_classifservofic", item.Atendimento?.Id.GetDBNullOrValue());
            AddParameters("ch_ql_servoficial", item.TipoServicoId?.GetDBNullOrValue());
            AddParameters("vc_cd_classifservofic", item.CodigoServico.GetDBNullOrValue());
            AddParameters("ch_fg_divulgado_classifservofic", item.Divulgado?.Id.GetDBNullOrValue());
            AddParameters("ch_cd_area", item.AreaId.GetDBNullOrValue());
            AddParameters("vc_nm_resumido_classifservofic", item.NomeResumido.GetDBNullOrValue());
            AddParameters("ch_fg_especialidade_grupoclassif", item.Especialidade?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_divulgado_site_classifservofic", item.DivulgadoSite?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_valecultura_classifservofic", item.ValeCultura?.Id.GetDBNullOrValue());
            AddParameters("in_sq_classificacaoservicost", item.ClassificacaoServicoId?.GetDBNullOrValue());
            AddParameters("in_sq_linhaservicost", item.LinhaServicoId?.GetDBNullOrValue());
            AddParameters("in_sq_plataformast", item.PlataformaId?.GetDBNullOrValue());
            AddParameters("in_sq_TUSS", item.TUSSId?.GetDBNullOrValue());
            AddParameters("sd_dt_validade_classifservofic", item.Validade?.GetDBNullOrValue());
            AddStroredProcedure("[dbo].[SPAlterarClassifServicoOficial]");

            var ret = ExecuteStoredProcedure();
            if (ret.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", ret.Message) });
            }

            return Task.FromResult(item);
        }

        public override Task<Produto> Adicionar(Produto item)
        {
            AddParameters("vc_ds_servoficial_classif", item.Descricao.GetDBNullOrValue());
            AddParameters("ch_fg_atendimento_classifservofic", item.Atendimento?.Id.GetDBNullOrValue());
            AddParameters("ch_ql_servoficial", item.TipoServicoId.GetDBNullOrValue());
            AddParameters("ch_tp_entidade_vinculo", item.TipoEntidadeVinculoId.GetDBNullOrValue());
            AddParameters("ch_cd_area", item.AreaId.GetDBNullOrValue());
            AddParameters("vc_nm_resumido_classifservofic", item.NomeResumido.GetDBNullOrValue());
            AddParameters("si_sq_tabservico", item.TabelaServicoId.GetDBNullOrValue());
            AddParameters("ti_nr_nivelservico", item.NivelServicoId.GetDBNullOrValue());
            AddParameters("vc_sq_classifservofic_especialidade", item.CodigoServicoEspecialidade.GetDBNullOrValue());
            AddParameters("in_sq_grupoclassif_primeironivel", item.GrupoClassificacaoPrimeiroNivelId.GetDBNullOrValue());
            AddParameters("in_sq_grupoclassif", item.GrupoClassificacaoId.GetDBNullOrValue());
            AddParameters("ch_cd_funcaoservtec", item.FuncaoServicoTecnologicoCodigo.GetDBNullOrValue());
            AddParameters("vc_cd_classifservofic", item.CodigoServico.GetDBNullOrValue());
            AddParameters("ch_fg_divulgado_classifservofic", item.Divulgado?.Id.GetDBNullOrValue());
            AddParameters("ch_ql_categoria_classifservofic", item.Categoria?.Id.GetValueOrDefault());
            AddParameters("sd_dt_fim_classifservofic", item.Fim?.GetDBNullOrValue());
            AddParameters("ch_fg_especialidade_grupoclassif", item.Especialidade?.Id.GetDBNullOrValue());
            AddParameters("in_sq_classifservofic", item.Id.GetDBNullOrValue(),System.Data.ParameterDirection.Output);
            AddParameters("ch_fg_divulgado_site_classifservofic", item.DivulgadoSite?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_valecultura_classifservofic", item.ValeCultura?.Id.GetDBNullOrValue());
            AddParameters("in_sq_classificacaoservicost", item.ClassificacaoServicoId.GetDBNullOrValue());
            AddParameters("in_sq_linhaservicost", item.LinhaServicoId.GetDBNullOrValue());
            AddParameters("in_sq_plataformast", item.PlataformaId.GetDBNullOrValue());
            AddParameters("in_sq_TUSS", item.TUSSId.GetDBNullOrValue());
            AddParameters("sd_dt_validade_classifservofic", item.Validade?.GetDBNullOrValue());
            AddStroredProcedure("[dbo].[SPIncluirClassifServicoOficial]");

            ObjectResult ret ;

            try
            {
               ret =  ExecuteStoredProcedure();
            }
            catch (SqlException ex)
            {
                item.ValidationResult.Errors.Add(new ValidationFailure("Error", ex.Message));
                return Task.FromResult(item);
            }

            if (ret.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", ret.Message) });
                return Task.FromResult(item);
            }

            item.Id = GetParamOutPutValue<int>();
            
            return Task.FromResult(item);
        }

        public override Task<Produto> Remover(Produto item)
        {
            AddParameters("in_sq_classifservofic", item.Id.GetDBNullOrValue());
            AddStroredProcedure("[dbo].[SPExcluirClassifServicoOficial]");

            var ret = ExecuteStoredProcedure();
            if (ret.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", ret.Message) });
            }

            return Task.FromResult(item);
        }
    }
}