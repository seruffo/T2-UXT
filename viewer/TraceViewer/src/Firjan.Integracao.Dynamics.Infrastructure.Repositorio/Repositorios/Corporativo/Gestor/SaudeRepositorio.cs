using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using FluentValidation.Results;
using System.Linq;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor
{
    public class SaudeRepositorio : CorporativoRepositorio<Domain.Models.Corporativo.Gestor.Saude>, ISaudeRepository
    {
        protected const string StoredProcedureConsultar = "[dbo].[sp_SaudeConsultarPropriedades] ";
        protected const string StoredProcedureAtualizar = "[dbo].[sp_SaudeRegistrarPropriedades] ";
        protected const string StoredProcedureExcluir = "[dbo].[sp_DeleteSaude] ";
        public SaudeRepositorio() : base() { }
        public SaudeRepositorio(CorporativoContext context) : base(context) { }

        public override async Task<IEnumerable<Domain.Models.Corporativo.Gestor.Saude>> ComFiltros(string colunaOrdenacao, bool? asc, Expression<Func<Domain.Models.Corporativo.Gestor.Saude, bool>> filtro, int qtd, int pule, IEnumerable<string> includes)
        {
            return await base.ComFiltros(colunaOrdenacao, asc, filtro, qtd, pule, includes)
                .ContinueWith((g) =>
                {
                    return g.Result.Where(c => (c.Fim ?? Convert.ToDateTime("2079-06-06")) > DateTime.Now);
                });
        }

        public override Task<Domain.Models.Corporativo.Gestor.Saude> FirstOrDefault(Expression<Func<Domain.Models.Corporativo.Gestor.Saude, bool>> expression, IEnumerable<string> includes)
        {
            return base.ComFiltros(null, null, expression, 1, 0, includes)
                .ContinueWith((g) =>
                {
                    return g.Result.Where(c => (c.Fim ?? Convert.ToDateTime("2079-06-06")) > DateTime.Now).FirstOrDefault();
                });
        }

        public override Task<Domain.Models.Corporativo.Gestor.Saude> Adicionar(Domain.Models.Corporativo.Gestor.Saude item)
        {
            return Atualizar(item);
        }

        public override Task<Domain.Models.Corporativo.Gestor.Saude> Remover(Domain.Models.Corporativo.Gestor.Saude item)
        {
            AddParameters("in_sq_classifservofic_saude", item.ProdutoId.GetDBNullOrValue());
            AddStroredProcedure(StoredProcedureExcluir);

            var result = ExecuteStoredProcedure();

            if (result.ErrorCod > 0)
            {
                item.ValidationResult.Errors.Add(new ValidationFailure("Error", result.Message));
            }

            return Task.FromResult(item);
        }

        public override Task<Domain.Models.Corporativo.Gestor.Saude> Atualizar(Domain.Models.Corporativo.Gestor.Saude item)
        {
            AddParameters("in_sq_classifservofic", item.ProdutoId.GetDBNullOrValue());
            AddParameters("vc_cd_classifservofic", item.CodigoServico.GetDBNullOrValue());
            AddParameters("vc_ds_resumido_servoficial", item.Produto?.NomeResumido.GetDBNullOrValue());
            AddParameters("ch_fg_marcahr_saude", item.MarcarHora?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_quantificavel_saude", item.Quantificavel?.Id.GetDBNullOrValue());
            AddParameters("sd_hr_tempoatend_saude", item.TempoAtendimento.GetDBNullOrValue());
            AddParameters("vc_ds_procprep_servoficial_saude", item.ProcedimentoPrepartorio.GetDBNullOrValue());
            AddParameters("ch_fg_tpserv_saude", item.TipoServicoSaude?.Id.GetDBNullOrValue());
            AddParameters("ch_cd_origem_saude ", item.OrigemSaude?.Id.GetDBNullOrValue());
            AddParameters("ch_tp_origemocup_saude", item.TipoOrigemServico?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_tpproc_saude", item.TipoProcedimento?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_exame_saude", item.Exame?.Id.GetDBNullOrValue());
            AddParameters("si_sq_classifexame", item.ClassificacaoExameId?.GetDBNullOrValue());
            AddParameters("ch_fg_tiporesultado_saude", item.TipoResultado?.Id.GetDBNullOrValue());
            AddParameters("vc_in_sq_tpregatend", item.TipoFicha.GetDBNullOrValue());
            AddParameters("in_nr_random", new Random().Next());
            AddParameters("ch_fg_dedutivel_classifservofic", item.Produto?.Dedutivel.Id.GetDBNullOrValue());
            AddParameters("ch_fg_tpClassif_saude", item.TipoClassificacao?.Id.GetDBNullOrValue());
            AddParameters("ch_tp_servOdonto_saude", item.TipoServicoOdontologico?.Id.GetDBNullOrValue());
            AddParameters("ti_qt_DentesEnvolvidos_saude", item.QtdDentesEnvolvidos?.Id.GetDBNullOrValue());
            AddParameters("ch_nr_agente", item.Produto?.NumeroAgente);
            AddParameters("bi_fg_agendaTeleAtend_saude", item.AgendaTeleatendimento.GetValueOrDefault());
            AddParameters("bi_fg_exigeCPF_classifservofic", item.Produto?.ExigeCPF.GetValueOrDefault());
            AddStroredProcedure(StoredProcedureAtualizar);
            
            var result = ExecuteStoredProcedure();
            
            if(result.ErrorCod > 0)
            { 
                item.ValidationResult.Errors.Add(new ValidationFailure("Error", result.Message));
            }

            return Task.FromResult(item);
        }        
    }
}