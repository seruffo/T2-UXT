using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.BaseRepositorio;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.SRC
{
    public class SRCRepositorio<TEntity> : BaseRepositorio<TEntity> where TEntity : class
    {
        public SRCRepositorio(CorporativoContext context) : base(context) { }
    }
}