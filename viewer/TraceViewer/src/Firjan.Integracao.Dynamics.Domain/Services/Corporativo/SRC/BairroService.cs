using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.SRC;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.SRC
{
    public class BairroService : BaseService<Bairro>, IBairroService
    {
        public BairroService(IBairroRepository repository, BairroValidator validator) : base(repository, validator) { }
    }
}
