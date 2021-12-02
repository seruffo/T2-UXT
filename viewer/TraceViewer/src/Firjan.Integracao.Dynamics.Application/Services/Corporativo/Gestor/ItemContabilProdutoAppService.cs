using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{
    public class ItemContabilProdutoAppService : BaseAppService<ItemContabilProduto,ItemContabilProdutoViewModel> , IItemContabilProdutoAppService
    {
        public ItemContabilProdutoAppService(IMapper mapper, IItemContabilProdutoService itemContabilProdutoService) : base(mapper, itemContabilProdutoService, null) { }
    }
}
