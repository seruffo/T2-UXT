using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor.Odontograma;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor.Odontograma
{
    public class OdontogramaAppService : BaseAppService<Domain.Models.Corporativo.Gestor.Odontograma.Odontograma, OdontogramaViewModel> , IOdontogramaAppService
    {
        public static readonly string[] includes = { "Atendimento", "Pessoa", "FiguraOdontograma" };
        public OdontogramaAppService(IMapper mapper, IOdontogramaService odontogramaService) : base(mapper, odontogramaService, includes) { }
    }
}
