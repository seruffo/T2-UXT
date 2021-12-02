
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class QuantificavelView : Enumeration
    {
        [DataMember]
        public static QuantificavelView Sim = new QuantificavelView('S', "Sim");
        [DataMember]
        public static QuantificavelView Nao = new QuantificavelView('N', "Não");
        public QuantificavelView(char? key, string displayName) : base(key, displayName) { }
    }

}
