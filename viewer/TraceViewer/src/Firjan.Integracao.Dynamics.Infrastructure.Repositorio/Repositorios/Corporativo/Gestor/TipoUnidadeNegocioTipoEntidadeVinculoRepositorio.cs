using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor
{
    public class TipoUnidadeNegocioTipoEntidadeVinculoRepositorio : CorporativoRepositorio<TipoUnidadeNegocioTipoEntidadeVinculo>, ITipoUnidadeNegocioTipoEntidadeVinculoRepository
    {
        public TipoUnidadeNegocioTipoEntidadeVinculoRepositorio(CorporativoContext context) : base(context) { }

        public override Task<TipoUnidadeNegocioTipoEntidadeVinculo> Remover(TipoUnidadeNegocioTipoEntidadeVinculo item)
        {
            AddParameters("si_sq_tpunnegtpentvinc", item.Id.GetDBNullOrValue());
            AddStroredProcedure("[dbo].[sp_TpUnNegTpEntVincExcluir]");

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