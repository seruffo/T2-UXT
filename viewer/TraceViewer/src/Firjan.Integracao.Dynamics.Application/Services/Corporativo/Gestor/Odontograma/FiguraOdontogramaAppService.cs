using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{
    public class FiguraOdontogramaAppService : BaseAppService<FiguraOdontograma, FiguraOdontogramaViewModel> , IFiguraOdontogramaAppService
    {
        public FiguraOdontogramaAppService(IMapper mapper, IFiguraOdontogramaService figuraOdontogramaService) : base(mapper, figuraOdontogramaService, null) { }
    }
}
