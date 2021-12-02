using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.STI;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.STI
{

    public class PlataformaAppService : BaseAppService<Plataforma, PlataformaViewModel>, IPlataformaAppService
    {
        public static readonly string[] includes = { "Area" };
        public PlataformaAppService(IMapper mapper, IPlataformaService service) : base(mapper, service, includes) { }
    } 
      
}
