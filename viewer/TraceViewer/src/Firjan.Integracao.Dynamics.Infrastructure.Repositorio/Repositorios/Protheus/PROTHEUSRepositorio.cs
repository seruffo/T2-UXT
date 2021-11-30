
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.BaseRepositorio;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Protheus;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Protheus
{
    public class ProtheusRepositorio<TEntity> : BaseRepositorio<TEntity> where TEntity : class
    {
        public ProtheusRepositorio(ProtheusContext context) : base(context)
        {
        }
    }
}