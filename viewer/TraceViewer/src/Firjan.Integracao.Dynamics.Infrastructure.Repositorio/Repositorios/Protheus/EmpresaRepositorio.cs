using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Protheus;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Protheus
{
    public class EmpresaRepositorio : CorporativoRepositorio<Empresa>, IEmpresaRepository
    {
        public EmpresaRepositorio(CorporativoContext context) : base(context) { }
    }
}