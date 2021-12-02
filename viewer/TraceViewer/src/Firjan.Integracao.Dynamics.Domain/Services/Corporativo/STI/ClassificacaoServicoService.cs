using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.STI;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.STI
{
    public class ClassificacaoServicoService : BaseService<ClassificacaoServico>, IClassificacaoServicoService
    {
        public ClassificacaoServicoService(IClassificacaoServicoRepository repository, ClassificacaoServicoValidator validator) : base(repository, validator) { }
    }
}
