using Firjan.Integracao.Dynamics.Application.Interfaces.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor
{
    public interface ITabelaServicoTipoEntidadeVinculoAppService : IAppService<TabelaServicoTipoEntidadeVinculoViewModel>
    {
        Task<IEnumerable<TabelaServicoTipoEntidadeVinculoViewModel>> GetTabelasServicos(string CodigoTipoEntidadeVinculo);
    }
}
