using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;
using System;
using System.Linq.Expressions;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Protheus
{
    public class ItemContabilAppService : BaseAppService<ItemContabil, ItemContabilViewModel>, IItemContabilAppService
    {
        protected static readonly Expression<Func<ItemContabilViewModel, bool>> expression = c => c.Empresa != "001" && c.Empresa != "002" && c.Empresa != "003" && c.Empresa != "004" && c.Empresa != "005" && c.Empresa != "006" && c.Empresa != "06rj" && c.Fim == null ;
           
        public ItemContabilAppService(IMapper mapper, IItemcontabilService service) : base(mapper, service, null, expression) { }
    }
}