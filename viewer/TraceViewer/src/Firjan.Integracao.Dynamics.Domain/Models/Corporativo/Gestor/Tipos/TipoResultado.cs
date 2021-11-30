using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoResultado : Enums<decimal>
    {
        public static TipoResultado MeioAmbiente = new TipoResultado(1, "Limites");
        public static TipoResultado AssistenciaSocial = new TipoResultado(2, "Positivo / Negativo");
        public TipoResultado(decimal key, string displayName) : base(key, displayName) { }
    }
}
