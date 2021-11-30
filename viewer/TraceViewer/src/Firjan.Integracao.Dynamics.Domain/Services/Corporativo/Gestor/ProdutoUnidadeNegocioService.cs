using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Gestor
{
    public class ProdutoUnidadeNegocioService : BaseService<ProdutoUnidadeNegocio>, IProdutoUnidadeNegocioService
    {
        public ProdutoUnidadeNegocioService(IProdutoUnidadeNegocioRepository repository, ProdutoUnidadeNegocioValidator validator) : base(repository, validator) { }
    }    
}
