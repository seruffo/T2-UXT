using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class Lazer : TipoModel<int>
    {
       public Produto Produto { get; set; }
       public TipoLazer TipoLazer { get; set; }
       public FamiliaLazer FamiliaLazer { get; set; }
    }
}
