using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Gestor.Odontograma
{
    public class FiguraOdontogramaService : BaseService<FiguraOdontograma> , IFiguraOdontogramaService
    {
        public FiguraOdontogramaService(IFiguraOdontogramaRepository repository, FiguraOdontogramaValidator validator) : base(repository,validator) { }
    }
}
