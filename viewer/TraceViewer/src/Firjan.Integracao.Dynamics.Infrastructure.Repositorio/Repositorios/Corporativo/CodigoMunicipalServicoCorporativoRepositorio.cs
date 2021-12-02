using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo
{
    public class CodigoMunicipalServicoCorporativoRepositorio : CorporativoRepositorio<CodigoMunicipalServicoCorporativo>, ICodigoMunicipalServicoCorporativoRepository
    {
        public CodigoMunicipalServicoCorporativoRepositorio(CorporativoContext context) : base(context) { }

        private void AddParameters(CodigoMunicipalServicoCorporativo item) 
        {
            AddParameters("in_sq_classifservOfic", item.CodigoServicoOficial);
            AddParameters("sd_dt_ini_classiftabservgoverno", item.Inicio);
            AddParameters("cod_serv_mun", item.CodigoMunicipalId);
            AddParameters("cod_municipio", item.CodigoMunicipio);
            AddParameters("sd_dt_fim_classiftabservgoverno", item.Fim);
        }

        public override Task<CodigoMunicipalServicoCorporativo> Adicionar(CodigoMunicipalServicoCorporativo item)
        {
            AddParameters("in_sq_classifservOfic", item.CodigoServicoOficial);
            AddParameters("sd_dt_ini_classiftabservgoverno", item.Inicio);
            AddParameters("cod_serv_mun", item.CodigoMunicipalId);
            AddParameters("cod_municipio", item.CodigoMunicipio);
            AddParameters("in_sq_municipio", item.SeqMunicipio);
            AddStroredProcedure("[dbo].[spClassifTabServicoGovernoIncluir]");

            var ret = ExecuteStoredProcedure();
            if (ret.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", ret.Message) });
            }

            return Task.FromResult(item);
        }

        public override Task<CodigoMunicipalServicoCorporativo> Atualizar(CodigoMunicipalServicoCorporativo item)
        {
            AddParameters(item);
            AddStroredProcedure("[dbo].[spClassifTabServicoGovernoAlterar]");

            var ret = ExecuteStoredProcedure();
            if (ret.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", ret.Message) });
            }

            return Task.FromResult(item);
        }

        public override Task<CodigoMunicipalServicoCorporativo> Remover(CodigoMunicipalServicoCorporativo item)
        {
            AddParameters(item);
            AddStroredProcedure("[dbo].[spClassifTabServicoGovernoExcluir]");
            var ret = ExecuteStoredProcedure();
            if (ret.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", ret.Message) });
            }
            return Task.FromResult(item);
        }
    }
}