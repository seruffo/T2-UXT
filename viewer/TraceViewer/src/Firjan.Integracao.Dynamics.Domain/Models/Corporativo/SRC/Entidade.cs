using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC
{
    public class Entidade : TipoModel<int>
    {
        public string TipoEntidadeVinculoId { get; set; }

        public TipoEntidadeVinculo TipoEntidadeVinculo { get; set; }
    }
}
