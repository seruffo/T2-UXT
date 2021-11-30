using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor.Odontograma
{
    public class FiguraOdontogramaRepositorio : CorporativoRepositorio<Domain.Models.Corporativo.Gestor.Odontograma.FiguraOdontograma>, IFiguraOdontogramaRepository
    {
        public FiguraOdontogramaRepositorio(CorporativoContext context) : base(context) { }

        public override Task<Domain.Models.Corporativo.Gestor.Odontograma.FiguraOdontograma> Remover(Domain.Models.Corporativo.Gestor.Odontograma.FiguraOdontograma item)
        {
            AddParameters("in_sq_figuraodontograma", item.Id.GetDBNullOrValue());
            AddStroredProcedure("[dbo].[spExcluirFiguraOdontograma] ");

            var ret = ExecuteStoredProcedure();
            if (ret.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", ret.Message) });
            }

            return Task.FromResult(item);
        }
    }
}