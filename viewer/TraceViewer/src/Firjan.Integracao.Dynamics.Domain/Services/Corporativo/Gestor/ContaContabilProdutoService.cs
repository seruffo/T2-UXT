using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor;
using FluentValidation;


namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Gestor
{
    public class ContaContabilProdutoService : BaseService<ContaContabilProduto> , IContaContabilProdutoService
    {
        public ContaContabilProdutoService(IContaContabilProdutoRepository repository, ContaContabilProdutoValidator validator) : base(repository,validator)
        {
        }
    }
}
