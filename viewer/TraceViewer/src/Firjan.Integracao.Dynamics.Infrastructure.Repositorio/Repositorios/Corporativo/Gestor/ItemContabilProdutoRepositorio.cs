using System.Collections.Generic;
using System.Threading.Tasks;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using FluentValidation.Results;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor
{
    public class ItemContabilProdutoRepositorio : CorporativoRepositorio<ItemContabilProduto>, IItemContabilProdutoRepository
    {
        public ItemContabilProdutoRepositorio(CorporativoContext context) : base(context) { }       

        public override Task<ItemContabilProduto> Atualizar(ItemContabilProduto item)
        {
            AddParameters("Empresa", item.CodigoEmpresa.GetDBNullOrValue());
            AddParameters("CodSub1", item.CodigoCentroResponsabilidade.GetDBNullOrValue());
            AddParameters("in_sq_classifservofic", item.ProdutoId.GetDBNullOrValue());
            AddParameters("sd_dt_ini_clservsubconta1", item.Inicio.GetDBNullOrValue());
            AddParameters("sd_dt_fim_clservsubconta1", item.Fim.GetDBNullOrValue());
            AddParameters("in_sq_grupoclassif", item.GrupoClassifId.GetDBNullOrValue());
            AddStroredProcedure("[dbo].[sp_ClServCRespAlterar]");

            var res = ExecuteStoredProcedure();
            if (res.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", res.Message) });
                return Task.FromResult(item);
            }

            return Task.FromResult(item);
        }

        public override Task<ItemContabilProduto> Adicionar(ItemContabilProduto item)
        {
            AddParameters("Empresa", item.CodigoEmpresa.GetDBNullOrValue());
            AddParameters("CodSub1", item.CodigoCentroResponsabilidade.GetDBNullOrValue());
            AddParameters("in_sq_classifservofic", item.ProdutoId.GetDBNullOrValue());
            AddParameters("sd_dt_ini_clservsubconta1", item.Inicio.GetDBNullOrValue());
            AddParameters("ch_fg_assistencial_ClSrvSubCta1", item.IsAssistencial.GetDBNullOrValue());
            AddParameters("in_sq_grupoclassif", item.GrupoClassifId.GetDBNullOrValue());
            AddStroredProcedure("[dbo].[sp_ClServCRespIncluir]");

            var res = ExecuteStoredProcedure();
            if(res.ErrorCod > 0 )
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", res.Message) });
                return Task.FromResult(item);
            }

            return Task.FromResult(item);
        }

        public override Task<ItemContabilProduto> Remover(ItemContabilProduto item)
        {
            AddParameters("Empresa", item.CodigoEmpresa.GetDBNullOrValue());
            AddParameters("CodSub1", item.CodigoCentroResponsabilidade.GetDBNullOrValue());
            AddParameters("in_sq_classifservofic", item.ProdutoId.GetDBNullOrValue());
            AddParameters("sd_dt_ini_clservsubconta1", item.Inicio.GetDBNullOrValue());
            AddParameters("sd_dt_fim_clservsubconta1", item.Fim.GetDBNullOrValue());
            AddStroredProcedure("[dbo].[sp_ClServCRespExcluir]");

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