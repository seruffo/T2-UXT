using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor
{
    public interface ITabelaServicoTipoEntidadeVinculoRepository : IBaseRepository<TabelaServicoTipoEntidadeVinculo>
    {
        Task<IEnumerable<TabelaServicoTipoEntidadeVinculo>> GetTabelasServicos(string CodigoTipoEntidade);
    }
}
