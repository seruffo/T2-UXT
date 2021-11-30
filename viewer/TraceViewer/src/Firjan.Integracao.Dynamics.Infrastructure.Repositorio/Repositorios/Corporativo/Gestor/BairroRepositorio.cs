using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor
{
    public class BairroRepositorio : CorporativoRepositorio<Bairro>, IBairroRepository
    {
        public BairroRepositorio(CorporativoContext context) : base(context) { }
    }
}