using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Services.Base;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Protheus
{
    public class ItemContabilService : BaseService<ItemContabil>, IItemcontabilService
    {
        public ItemContabilService(IItemContabilRepository repository) : base(repository) { }
    }
}
