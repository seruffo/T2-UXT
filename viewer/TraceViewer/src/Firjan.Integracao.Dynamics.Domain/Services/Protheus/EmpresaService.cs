using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Protheus;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Protheus;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Protheus;

namespace Firjan.Integracao.Dynamics.Domain.Services.Protheus
{
    public class EmpresaService : BaseService<Empresa> , IEmpresaService
    {
        public EmpresaService(IEmpresaRepository repository, EmpresaValidator validator) : base(repository,validator) { }
    }
}
