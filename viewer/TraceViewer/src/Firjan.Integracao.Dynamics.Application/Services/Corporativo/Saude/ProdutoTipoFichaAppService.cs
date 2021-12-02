using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Saude;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Saude
{
    public class ProdutoTipoFichaAppService : BaseAppService<ProdutoTipoFicha, ProdutoTipoFichaViewModel>, IProdutoTipoFichaAppService
    {
        public static readonly string[] includes = { "Produto", "TipoFicha", "Servico" };
        public ProdutoTipoFichaAppService(IMapper mapper, IProdutoTipoFichaService service) : base(mapper, service, includes) { }
    }
}