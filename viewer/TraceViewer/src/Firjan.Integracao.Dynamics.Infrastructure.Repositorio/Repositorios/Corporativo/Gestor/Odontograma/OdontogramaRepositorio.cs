using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor.Odontograma
{
    public class OdontogramaRepositorio : CorporativoRepositorio<Domain.Models.Corporativo.Gestor.Odontograma.Odontograma>, Domain.Interfaces.Repository.Corporativo.Gestor.Odontograma.IOdontogramaRepository
    {
        private const string LOGONINTEGRACAO = "INTEGRACAODYNAMICS";
        public OdontogramaRepositorio(CorporativoContext context) : base(context) { }

        public override Task<Domain.Models.Corporativo.Gestor.Odontograma.Odontograma> Remover(Domain.Models.Corporativo.Gestor.Odontograma.Odontograma item)
        {
            RemoverHistorico(item);

            if(item.ValidationResult.Errors.Count > 0) return Task.FromResult(item);

            ClearParameters();
            AddParameters("in_sq_pessoa", item.PessoaId.GetDBNullOrValue());
            AddParameters("ch_nr_atendOdont", item.AtendimentoId.GetDBNullOrValue());
            AddParameters("vc_ds_logon_sistema", LOGONINTEGRACAO);
            AddStroredProcedure("[dbo].[spOdontogramaExcluir] ");

            var ret = ExecuteStoredProcedure();
            if (ret.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", ret.Message) });
            }

            return Task.FromResult(item);
        }

        private Domain.Models.Corporativo.Gestor.Odontograma.Odontograma RemoverHistorico(Domain.Models.Corporativo.Gestor.Odontograma.Odontograma item)
        {
            ClearParameters();
            AddParameters("ch_nr_atendOdont", item.AtendimentoId.GetDBNullOrValue());
            AddParameters("vc_ds_logon_sistema", LOGONINTEGRACAO);
            AddStroredProcedure("[dbo].[spHistOdontogramaExcluir] ");

            var ret = ExecuteStoredProcedure();
            if (ret.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", ret.Message) });
            }

            return item;
        }

        public override Task<Domain.Models.Corporativo.Gestor.Odontograma.Odontograma> Adicionar(Domain.Models.Corporativo.Gestor.Odontograma.Odontograma item)
        {
            ClearParameters();
            AddParameters("in_sq_pessoa", item.PessoaId.GetDBNullOrValue());
            AddParameters("ch_nr_atendOdont", item.AtendimentoId.GetDBNullOrValue());
            AddParameters("in_sq_figuraodontograma", item.FiguraOdontogramaId.GetDBNullOrValue());
            AddParameters("ch_fg_operacao_odontograma", item.Operacao?.Id.GetDBNullOrValue());
            AddParameters("ti_nr_dente_odontograma", item.NumeroDente.GetDBNullOrValue());
            AddParameters("ch_nr_pto", DBNull.Value);
            AddParameters("ch_fg_radiografia_odontograma", item.Radiografia?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_raiz1_odontograma", item.Raiz1?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_raiz2_odontograma", item.Raiz2?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_raiz3_odontograma", item.Raiz3?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_face1_odontograma", item.Face1?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_face2_odontograma", item.Face2?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_face3_odontograma", item.Face3?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_face4_odontograma", item.Face4?.Id.GetDBNullOrValue());
            AddParameters("ch_fg_face5_odontograma", item.Face5?.Id.GetDBNullOrValue());
            AddParameters("in_sq_classifservoficAtend", DBNull.Value);
            AddParameters("ch_nr_atendOdont_referencia", DBNull.Value);
            AddParameters("vc_ds_logon_sistema", LOGONINTEGRACAO);
            AddStroredProcedure("[dbo].[spOdontogramaIncluir] ");

            var ret = ExecuteStoredProcedure();
            if (ret.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", ret.Message) });
            }

            return Task.FromResult(item);
        }
    }
}