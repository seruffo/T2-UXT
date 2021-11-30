using Firjan.Integracao.Dynamics.Domain.Models.Base;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class Risco : TipoModel<string>
    {
        public Agente Agente { get; set; }
        public string TipoRiscoId { get; set; }
        public TipoRisco TipoRisco { get; set; }
    }
}
