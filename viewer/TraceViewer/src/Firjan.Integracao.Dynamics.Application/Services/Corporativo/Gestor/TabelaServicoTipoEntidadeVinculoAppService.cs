using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Firjan.Integracao.Dynamics.Application.Utils;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Services.Base;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{

    public class TabelaServicoTipoEntidadeVinculoAppService : BaseAppService<TabelaServicoTipoEntidadeVinculo, TabelaServicoTipoEntidadeVinculoViewModel>, ITabelaServicoTipoEntidadeVinculoAppService
    {
        private readonly ITabelaServicoTipoEntidadeVinculoService _service;
        public TabelaServicoTipoEntidadeVinculoAppService(IMapper mapper, ITabelaServicoTipoEntidadeVinculoService service) : base(mapper, service, null, null)
        {
            _service = service;
        }

        public Task<IEnumerable<TabelaServicoTipoEntidadeVinculoViewModel>> GetTabelasServicos(string CodigoTipoEntidadeVinculo)
        {
            using (var retorno = _service.GetTabelasServicos(CodigoTipoEntidadeVinculo))
            {
                return Task.FromResult(_mapper.Map<IEnumerable<TabelaServicoTipoEntidadeVinculoViewModel>>(retorno.Result));
            }
        }

    }
}
