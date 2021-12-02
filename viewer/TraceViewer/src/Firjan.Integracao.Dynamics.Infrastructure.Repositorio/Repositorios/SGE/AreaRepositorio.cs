using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.SGE;
using Firjan.Integracao.Dynamics.Domain.Models.SGE;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.SGE;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.SGE
{
    public class AreaRepositorio : SGERepositorio<Area>, IAreaRepository
    {
        public AreaRepositorio(SGEContext context) : base(context) { }
    }
}