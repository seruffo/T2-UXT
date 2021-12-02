using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.STI
{
    public class ClassificacaoService : BaseService<Classificacao>, IClassificacaoService
    {
        public ClassificacaoService(IClassificacaoRepository repository, ClasssificacaoValidator validator) : base(repository, validator) { }
    }
}
