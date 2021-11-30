using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using System.Collections.Generic;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{
    public class EnderecoUnidadeAppService : BaseAppService<EnderecoUnidade, EnderecoUnidadeViewModel> , IEnderecoUnidadeAppService
    {
        private static IEnumerable<string> Includes => new string[] { "Municipio", "UnidadeNegocio", "Bairro" };
        public EnderecoUnidadeAppService(IMapper mapper, IEnderecoUnidadeService tussService) : base(mapper, tussService, Includes) { }
    }
}
