using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor
{
    public class TipoUnidadeNegocioRepositorio : CorporativoRepositorio<TipoUnidadeNegocio>, ITipoUnidadeNegocioRepository
    {
        protected const string StoredProcedureExcluir = "[dbo].[sp_TipoUnidadeNegocioExcluir] ";

        public TipoUnidadeNegocioRepositorio(CorporativoContext context) : base(context) { }

        public override Task<TipoUnidadeNegocio> Remover(TipoUnidadeNegocio item)
        {
            AddParameters("si_sq_tipounidade", item.Id.GetDBNullOrValue());
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
