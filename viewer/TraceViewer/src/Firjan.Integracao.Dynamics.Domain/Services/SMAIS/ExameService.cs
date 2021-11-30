using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.SMAIS;
using Firjan.Integracao.Dynamics.Domain.Models.SMAIS;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.SMAIS;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.SMAIS;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Gestor
{
    public class ExameService : BaseService<Exame>, IExameService
    {
        public ExameService(IExameRepository repository, ExameValidator validator) : base(repository, validator) { }
    }
}
