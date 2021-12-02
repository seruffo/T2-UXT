using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.STI
{
    public class FuncaoRepositorio : CorporativoRepositorio<Funcao>, IFuncaoRepository
    {
        public FuncaoRepositorio(CorporativoContext context) : base(context) { }
    }
}