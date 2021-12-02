using System.Collections.Generic;
using System.Threading.Tasks;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using FluentValidation.Results;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor
{
    public class ClasseValorProdutoRepositorio : CorporativoRepositorio<ClasseValorProduto>, IClasseValorProdutoRepository
    {
        public ClasseValorProdutoRepositorio(CorporativoContext context) : base(context) { }

        public override Task<ClasseValorProduto> Atualizar(ClasseValorProduto item)
        {
            AddParameters("Empresa", item.CodigoEmpresa.GetDBNullOrValue());
            AddParameters("CodSub2", item.CodigoCentroResponsabilidade.GetDBNullOrValue());
            AddParameters("in_sq_classifservofic", item.ProdutoId.GetDBNullOrValue());
            AddParameters("sd_dt_ini_clservsubconta2", item.Inicio.GetDBNullOrValue());
            AddParameters("sd_dt_fim_clservsubconta2", item.Fim.GetDBNullOrValue());
            AddParameters("in_sq_grupoclassif", item.GrupoClassifId.GetDBNullOrValue());
            AddStroredProcedure("[dbo].[sp_ClServSubConta2Alterar]");

            var res = ExecuteStoredProcedure();
            if (res.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", res.Message) });
                return Task.FromResult(item);
            }

            return Task.FromResult(item);
        }

        public override Task<ClasseValorProduto> Adicionar(ClasseValorProduto item)
        {
            AddParameters("Empresa", item.CodigoEmpresa.GetDBNullOrValue());
            AddParameters("CodSub2", item.CodigoCentroResponsabilidade.GetDBNullOrValue());
            AddParameters("in_sq_classifservofic", item.ProdutoId.GetDBNullOrValue());
            AddParameters("sd_dt_ini_clservsubconta2", item.Inicio.GetDBNullOrValue());
            AddParameters("in_sq_grupoclassif", item.GrupoClassifId.GetDBNullOrValue());
            AddStroredProcedure("[dbo].[sp_ClServSubConta2Incluir]");

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