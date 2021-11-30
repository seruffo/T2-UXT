using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor;


namespace Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Gestor.Odontograma
{
    public class OdontogramaService : BaseService<Models.Corporativo.Gestor.Odontograma.Odontograma> , IOdontogramaService
    {
        public OdontogramaService(IOdontogramaRepository repository, OdontogramaValidator validator) : base(repository,validator)
        {
        }
    }
}
