using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using System.Collections.Generic;

namespace Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor
{
    public interface IEmpresaEntidadeVinculoRepository : IBaseRepository<EmpresaEntidadeVinculo>
    {
        IEnumerator<string> GetTiposEntidadesVinculosIds(string empresaId);
    }
}
