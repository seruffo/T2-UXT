using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.STI;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.STI
{
    public class LinhaServicoService : BaseService<LinhaServico>, ILinhaServicoService
    {
        public LinhaServicoService(ILinhaServicoRepository repository, LinhaServicoValidator validator) : base(repository, validator) { }
    }
}
