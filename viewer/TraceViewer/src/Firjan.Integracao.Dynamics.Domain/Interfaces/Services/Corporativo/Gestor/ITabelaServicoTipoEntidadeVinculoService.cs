using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor
{
    public interface ITabelaServicoTipoEntidadeVinculoService : IDisposable, IService<TabelaServicoTipoEntidadeVinculo>
    {
        Task<IEnumerable<TabelaServicoTipoEntidadeVinculo>> GetTabelasServicos(string CodigoTipoEntidadeVinculo);
    }
}
