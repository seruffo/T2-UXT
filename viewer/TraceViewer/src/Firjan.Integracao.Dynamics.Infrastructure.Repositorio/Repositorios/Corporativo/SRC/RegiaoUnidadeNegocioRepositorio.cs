using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.SRC
{
    public class RegiaoUnidadeNegocioRepositorio : CorporativoRepositorio<RegiaoUnidadeNegocio>, IRegiaoUnidadeNegocioRepository
    {
        public RegiaoUnidadeNegocioRepositorio(CorporativoContext context) : base(context) { }
    }
}