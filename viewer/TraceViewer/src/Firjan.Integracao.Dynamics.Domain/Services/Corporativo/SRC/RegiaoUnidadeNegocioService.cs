using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.SRC;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.SRC
{
    public class RegiaoUnidadeNegocioService : BaseService<RegiaoUnidadeNegocio>, IRegiaoUnidadeNegocioService
    {
        public RegiaoUnidadeNegocioService(IRegiaoUnidadeNegocioRepository repository, RegiaoUnidadeNegocioValidator validator) : base(repository, validator) { }
    }
}
