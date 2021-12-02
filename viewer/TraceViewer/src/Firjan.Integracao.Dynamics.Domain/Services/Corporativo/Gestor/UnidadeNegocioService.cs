using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Gestor
{
    public class UnidadeNegocioService : BaseService<UnidadeNegocio>, IUnidadeNegocioService
    {
        public UnidadeNegocioService(IUnidadeNegocioRepository repository, UnidadeNegocioValidator validator) : base(repository, validator) { }
    }
}
