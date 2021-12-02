using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor.Odontograma
{
    public class SaudeFiguraOdontogramaAppService : BaseAppService<SaudeFiguraOdontograma, SaudeFiguraOdontogramaViewModel>, ISaudeFiguraOdontogramaAppService
    {
        public static readonly string[] includes = { "Saude", "FiguraOdontograma"};
        public SaudeFiguraOdontogramaAppService(IMapper mapper, ISaudeFiguraOdontogramaService saudeFiguraOdontogramaService) : base(mapper, saudeFiguraOdontogramaService, includes)
        {            
        }
    }
}
