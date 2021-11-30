using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Application.ViewModels.Protheus;
using Firjan.Integracao.Dynamics.Application.Interfaces.Protheus;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Protheus;

namespace Firjan.Integracao.Dynamics.Application.Services.Protheus
{
    public class EmpresaAppService : BaseAppService<Empresa, EmpresaViewModel> , IEmpresaAppService
    {
        public EmpresaAppService(IMapper mapper, IEmpresaService empresaService) : base(mapper, empresaService, null, null ) { }
    }
}
