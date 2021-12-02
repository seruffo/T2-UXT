using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Saude;

namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Saude
{
    public class ProdutoTipoFichaService : BaseService<ProdutoTipoFicha>, IProdutoTipoFichaService
    {
        public ProdutoTipoFichaService(IProdutoTipoFichaRepository repository, ProdutoTipoFichaValidator validator) : base(repository, validator) { }
    }
}
