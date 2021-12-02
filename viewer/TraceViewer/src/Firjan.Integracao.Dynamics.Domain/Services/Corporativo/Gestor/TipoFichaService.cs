using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Saude;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Gestor
{
    public class TipoFichaService : BaseService<TipoFicha>, ITipoFichaService
    {
        public TipoFichaService(ITipoFichaRepository repository, TipoFichaValidator validator) : base(repository, validator) { }
    }
}
