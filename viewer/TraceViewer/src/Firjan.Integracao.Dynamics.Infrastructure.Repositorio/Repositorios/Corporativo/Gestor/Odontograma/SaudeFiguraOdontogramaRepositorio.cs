using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor.Odontograma
{
    public class SaudeFiguraOdontogramaRepositorio : CorporativoRepositorio<SaudeFiguraOdontograma>, ISaudeFiguraOdontogramaRepository
    {
        public SaudeFiguraOdontogramaRepositorio(CorporativoContext context) : base(context) { }

        public override Task<SaudeFiguraOdontograma> Remover(SaudeFiguraOdontograma item)
        {
            AddParameters("in_sq_classifservofic_saude", item.SaudeId.GetDBNullOrValue());
            AddParameters("in_sq_figuraodontograma ", item.FiguraOdontogramaId.GetDBNullOrValue());
            AddStroredProcedure("[dbo].[spExcluirSaudeFiguraOdontograma]");

            var ret = ExecuteStoredProcedure();
            if (ret.ErrorCod > 0)
            {
                item.ValidationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", ret.Message) });
            }

            return Task.FromResult(item);
        }
    }
}