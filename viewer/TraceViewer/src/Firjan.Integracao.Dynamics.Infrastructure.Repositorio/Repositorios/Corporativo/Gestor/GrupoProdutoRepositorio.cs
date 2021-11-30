using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor
{
    public class GrupoProdutoRepositorio : CorporativoRepositorio<GrupoClassificacao>
    {
        public GrupoProdutoRepositorio() : base() { }

        public GrupoProdutoRepositorio(CorporativoContext context) : base(context) { }
    }
}