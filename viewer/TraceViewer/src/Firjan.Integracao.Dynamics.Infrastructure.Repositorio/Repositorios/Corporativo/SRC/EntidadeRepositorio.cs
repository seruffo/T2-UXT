using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.SRC;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.SRC
{
    public class EntidadeRepositorio : SRCRepositorio<Entidade>, IEntidadeRepository
    {
        public EntidadeRepositorio(CorporativoContext context) : base(context) { }
    }
}