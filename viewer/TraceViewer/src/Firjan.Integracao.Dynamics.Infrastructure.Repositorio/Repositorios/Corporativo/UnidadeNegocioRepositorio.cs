using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo
{
    public class UnidadeNegocioRepositorio : CorporativoRepositorio<UnidadeNegocio>, IUnidadeNegocioRepository
    {
        protected const string StoredProcedureExcluir = "[dbo].[SPUnidadeNegocioExcluir] ";

        public UnidadeNegocioRepositorio(CorporativoContext context) : base(context) { }

        public override Task<UnidadeNegocio> Remover(UnidadeNegocio item)
        {
            AddParameters("si_sq_unidnegocio", item.Id.GetDBNullOrValue());
            AddStroredProcedure(StoredProcedureExcluir);

            var result = ExecuteStoredProcedure();

            if (result.ErrorCod > 0)
            {
                item.ValidationResult.Errors.Add(new ValidationFailure("Error", result.Message));
            }

            return Task.FromResult(item);
        }
    }
}