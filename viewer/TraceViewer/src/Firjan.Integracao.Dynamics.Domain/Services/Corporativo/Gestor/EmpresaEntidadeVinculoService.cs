using System.Collections.Generic;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Gestor
{
    public class EmpresaEntidadeVinculoService : BaseService<EmpresaEntidadeVinculo> , IEmpresaEntidadeVinculoService
    {
        private new readonly IEmpresaEntidadeVinculoRepository _repository;
        public EmpresaEntidadeVinculoService(IEmpresaEntidadeVinculoRepository repository, EmpresaEntidadeVinculoValidator validator) : base(repository,validator)
        {
            _repository = repository;
        }

        public IEnumerator<string> GetTiposEntidadesVinculosIds(string empresaId)
        {
            return _repository.GetTiposEntidadesVinculosIds(empresaId);
        }
    }
}
