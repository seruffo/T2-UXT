using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor
{
    public class EnderecoUnidadeRepositorio : CorporativoRepositorio<EnderecoUnidade>, IEnderecoUnidadeRepository
    {
        public EnderecoUnidadeRepositorio(CorporativoContext context) : base(context) { }
    }
}