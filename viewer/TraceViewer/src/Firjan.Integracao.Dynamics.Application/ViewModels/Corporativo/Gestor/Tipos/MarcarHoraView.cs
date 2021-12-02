
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class MarcarHoraView : Enumeration
    {
        [DataMember]
        public static MarcarHoraView Sim = new MarcarHoraView('S', "Sim");
        [DataMember]
        public static MarcarHoraView Nao = new MarcarHoraView('N', "Não");
        public MarcarHoraView(char? key, string displayName) : base(key, displayName) { }
    }

}
