using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.STI;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.STI
{
    public class PlataformaService : BaseService<Plataforma>, IPlataformaService
    {
        public PlataformaService(IPlataformaRepository repository, PlataformaValidator validator) : base(repository, validator) { }
    }
}
