using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class TipoResultadoView : Enums<decimal>
    {
        [DataMember]
        public static TipoResultadoView MeioAmbiente = new TipoResultadoView(1, "Limites");
        [DataMember]
        public static TipoResultadoView AssistenciaSocial = new TipoResultadoView(2, "Positivo / Negativo");
        public TipoResultadoView(decimal key, string displayName) : base(key, displayName) { }
    }
}
