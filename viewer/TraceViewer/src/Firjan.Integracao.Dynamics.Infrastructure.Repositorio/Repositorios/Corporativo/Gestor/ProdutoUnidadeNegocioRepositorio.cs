using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor
{
    public class ProdutoUnidadeNegocioRepositorio : CorporativoRepositorio<ProdutoUnidadeNegocio>, IProdutoUnidadeNegocioRepository
    {
        public ProdutoUnidadeNegocioRepositorio(CorporativoContext context) : base(context) {}
    }
}