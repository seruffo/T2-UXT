using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Saude
{
    public class TipoFichaRepositorio : CorporativoRepositorio<TipoFicha>, ITipoFichaRepository
    {
        public TipoFichaRepositorio(CorporativoContext context) : base(context) { }
    }
}