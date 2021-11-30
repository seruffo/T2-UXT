using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Saude;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Gestor
{
    public class SaudeService : BaseService<Models.Corporativo.Gestor.Saude> , ISaudeService
    {
        public SaudeService(ISaudeRepository repository, SaudeValidator validator) : base(repository,validator) { }
    }
}
