using System.Collections.Generic;
using System.Threading.Tasks;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Gestor
{
    public class TabelaServicoTipoEntidadeVinculoService : BaseService<TabelaServicoTipoEntidadeVinculo>, ITabelaServicoTipoEntidadeVinculoService
    {
        new readonly ITabelaServicoTipoEntidadeVinculoRepository _repository;
        public TabelaServicoTipoEntidadeVinculoService(ITabelaServicoTipoEntidadeVinculoRepository repository, 
            TabelaServicoTipoEntidadeVinculoValidator validator) : base(repository, validator)
        {
            _repository = repository;
        }

        public Task<IEnumerable<TabelaServicoTipoEntidadeVinculo>> GetTabelasServicos(string CodigoTipoEntidadeVinculo)
        {
            return _repository.GetTabelasServicos(CodigoTipoEntidadeVinculo);
        }
    }
}
