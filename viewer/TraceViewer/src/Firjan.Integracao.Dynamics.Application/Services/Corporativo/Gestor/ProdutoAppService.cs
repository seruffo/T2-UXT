using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using System.Collections.Generic;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{
    public class ProdutoAppService : BaseAppService<Produto, ProdutoViewModel> , IProdutoAppService
    {
        private static IEnumerable<string> Includes => new string[] {
            "GrupoClassificacaoPrimeiroNivel",
            "GrupoClassificacao",
            "ClassificacaoServico",
            "FuncaoServicoTecnologico",
            "TipoEntidadeVinculo",
            "TabelaServico",
            "NivelServico",
            "TUSS",
            "LinhaServico",
            "Plataforma",
            "ProdutoEspecialidade",
            "TipoServico",
            "Area"
        }; 

        public ProdutoAppService(IMapper mapper, IProdutoService produtoService) : base(mapper, produtoService, Includes) { }
    }
}
