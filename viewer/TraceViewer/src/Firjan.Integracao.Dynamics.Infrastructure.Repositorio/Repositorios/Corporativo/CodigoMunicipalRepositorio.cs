using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo
{
    public class CodigoMunicipalRepositorio : CorporativoRepositorio<CodigoMunicipal>, ICodigoMunicipalRepository
    {
        public CodigoMunicipalRepositorio(CorporativoContext context) : base(context) { }
    }
}