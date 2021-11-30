using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using FluentValidation.Results;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor
{
    public class ModuloVersaoRepositorio : CorporativoRepositorio<ModuloVersao>, IModuloVersaoRepository
    {
        public ModuloVersaoRepositorio(CorporativoContext context) : base(context) { }

        public override Task<ModuloVersao> Atualizar(ModuloVersao item)
        {
            AddParameters("ch_cd_modulo", item.Codigo.GetDBNullOrValue());
            AddParameters("ch_nr_moduloversao", item.NumeroVersao.GetDBNullOrValue());
            AddParameters("si_qt_horas_moduloversao", item.QtdHoras.GetDBNullOrValue());
            AddParameters("si_qt_dias_moduloversao", item.QtddDias.GetDBNullOrValue());
            AddParameters("sd_dt_fim_moduloversao", item?.Fim.GetDBNullOrValue());
            AddParameters("si_sq_tipomodal", item.TipoModalidadeId.GetDBNullOrValue());
            AddParameters("ch_cd_instrucao", item.CodigoInstrucao.GetDBNullOrValue());
            AddParameters("si_qt_horasEstag_modversao", item.QtdHorasEstagio.GetDBNullOrValue());
            AddParameters("ch_fg_tipo_modulo", item.TipoModulo.Id.GetDBNullOrValue());
            AddParameters("ch_fg_geranum_certificado", item.GeraNumeroCertificado?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_contem_disciplina", item.ContemDisciplina?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_refazcurso_moduloversao", item.RefazCurso?.Id.GetDBNullOrValue());
            AddParameters("in_sq_portifolioeducacao", item.PortifolioEducacaoId.GetDBNullOrValue());
            AddParameters("bi_fg_processoseletivo_moduloversao", item.FlagProcessoSeletivo?1:0);
            AddParameters("ch_fg_custosistema_moduloversao", item.CustoSistema.Id.GetDBNullOrValue());
            AddStroredProcedure("[dbo].[sp_ModVersaoAlterar]");

            var ret = ExecuteStoredProcedure();
            if (ret.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", ret.Message) });
            }

            return Task.FromResult(item);
        }

        public override Task<ModuloVersao> Adicionar(ModuloVersao item)
        {
            AddParameters("ch_cd_modulo", item.Codigo.GetDBNullOrValue());
            AddParameters("ch_nr_moduloversao", item.NumeroVersao.GetDBNullOrValue());
            AddParameters("si_qt_horas_moduloversao", item.QtdHoras.GetDBNullOrValue());
            AddParameters("si_qt_dias_moduloversao", item.QtddDias.GetDBNullOrValue());
            AddParameters("sd_dt_fim_moduloversao", item.Fim.GetDBNullOrValue());
            AddParameters("vc_ds_conteudo_moduloversao", item.Descricao.GetDBNullOrValue());
            AddParameters("in_sq_classifservofic_moduloversao", item.ProdutoId.GetDBNullOrValue());
            AddParameters("si_sq_tipomodal", item.TipoModalidadeId.GetDBNullOrValue());
            AddParameters("ch_cd_instrucao", item.CodigoInstrucao.GetDBNullOrValue<char>());
            AddParameters("si_qt_horasEstag_modversao", item.QtdHorasEstagio.GetDBNullOrValue());
            AddParameters("ch_fg_tipo_modulo", item.TipoModulo?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_geranum_certificado", item.GeraNumeroCertificado?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_contem_disciplina", item.ContemDisciplina?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_refazcurso_moduloversao", item.RefazCurso?.Id.GetDBNullOrValue());
            AddParameters("in_sq_portifolioeducacao", item.PortifolioEducacaoId.GetDBNullOrValue());
            AddParameters("bi_fg_processoseletivo_moduloversao", item.FlagProcessoSeletivo);
            AddParameters("ch_fg_custosistema_moduloversao", item.CustoSistema?.Id.GetDBNullOrValue());
            AddParameters("ti_vl_idademin_educacao", item.IdadeMinimaEducacao.GetDBNullOrValue());
            AddParameters("ti_vl_idademax_educacao", item.IdadeMaximaEducacao.GetDBNullOrValue());
            AddParameters("vc_nm_moduloversao", item.Nome.GetDBNullOrValue());
            AddStroredProcedure("[dbo].[sp_ModVersaoIncluir]");

            var ret = ExecuteStoredProcedure();
            if (ret.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", ret.Message) });
            }

            return Task.FromResult(item);
        }

        public override Task<ModuloVersao> Remover(ModuloVersao item)
        {
            AddParameters("in_sq_classifservofic", item.ProdutoId.GetDBNullOrValue());
            AddStroredProcedure("[dbo].[sp_ModVersaoExcluir]");

            var ret = ExecuteStoredProcedure();
            if (ret.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", ret.Message) });
            }
            return Task.FromResult(item);
        }
    }
}