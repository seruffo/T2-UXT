using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.STI;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.STI
{
    public class AreaService : BaseService<Area>, IAreaService
    {
        public AreaService(IAreaRepository repository, AreaValidator validator) : base(repository, validator) { }
    }

}
