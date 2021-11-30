using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Protheus
{
    public class CentroCustoRepositorio : CorporativoRepositorio<CentroCusto>, ICentroCustoRepository
    {
        public CentroCustoRepositorio(CorporativoContext context)
            : base(context)
        {

        }
    }
}