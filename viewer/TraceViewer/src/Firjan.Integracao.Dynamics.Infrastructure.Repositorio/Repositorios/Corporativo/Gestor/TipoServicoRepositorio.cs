using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor
{
    public class TipoServicoRepositorio : CorporativoRepositorio<TipoServico>
    {
        public TipoServicoRepositorio() : base() { }
        public TipoServicoRepositorio(CorporativoContext context)
            : base(context)
        {
        }
    }
}