using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{
    public class ClasseValorProdutoAppService : BaseAppService<ClasseValorProduto, ClasseValorProdutoViewModel> , IClasseValorProdutoAppService
    {
        public ClasseValorProdutoAppService(IMapper mapper, IClasseValorProdutoService classeValorProdutoService) : base(mapper, classeValorProdutoService, null) { }
    }
}
