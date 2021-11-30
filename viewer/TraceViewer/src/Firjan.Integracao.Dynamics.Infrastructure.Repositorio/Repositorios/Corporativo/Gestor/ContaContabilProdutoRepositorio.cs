using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using FluentValidation.Results;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor
{
    public class ContaContabilProdutoRepositorio : CorporativoRepositorio<ContaContabilProduto>, IContaContabilProdutoRepository
    {
        public ContaContabilProdutoRepositorio(CorporativoContext context) : base(context) { }

        private void AddParameters(ContaContabilProduto item)
        {
            AddParameters("Empresa", item.CodigoEmpresa.GetDBNullOrValue());
            AddParameters("Conta", item.CodigoConta.GetDBNullOrValue());
            AddParameters("in_sq_classifservofic", item.ProdutoId.GetDBNullOrValue());
            AddParameters("sd_dt_ini_clservplanocta", item.Inicio.GetDBNullOrValue());
            AddParameters("sd_dt_fim_clservplanocta", item.Fim.GetDBNullOrValue());
            AddParameters("ch_fg_assistencial_planocta", item.IsAssistencial.GetDBNullOrValue());
        }

        public override Task<ContaContabilProduto> Atualizar(ContaContabilProduto item)
        {
            AddParameters(item);
            AddParameters("in_sq_grupoclassif", item.GrupoClassifId.GetDBNullOrValue());
            AddStroredProcedure("[dbo].[sp_ClServCtaEstAlterar]");

            var res = ExecuteStoredProcedure();
            if (res.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", res.Message) });
                return Task.FromResult(item);
            }

            return Task.FromResult(item);
        }

    }
}