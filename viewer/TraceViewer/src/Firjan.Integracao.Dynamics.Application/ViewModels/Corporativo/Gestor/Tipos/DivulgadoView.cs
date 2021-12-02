using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class DivulgadoView : Enumeration
    {
        [DataMember]
        public static DivulgadoView Sim = new DivulgadoView('S', "Sim");
        [DataMember]
        public static DivulgadoView Nao = new DivulgadoView('N', "Não");
        public DivulgadoView(char? key, string displayName) : base(key, displayName) { }
    }

}
