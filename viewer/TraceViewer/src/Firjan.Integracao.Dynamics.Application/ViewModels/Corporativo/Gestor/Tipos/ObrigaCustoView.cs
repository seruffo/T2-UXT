
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class ObrigaCustoView : Enumeration
    {
        [DataMember]
        public static ObrigaCustoView Sim = new ObrigaCustoView('S', "Sim");
        [DataMember]
        public static ObrigaCustoView nao = new ObrigaCustoView('N', "Não");
        public ObrigaCustoView(char? key, string displayName) : base(key, displayName) { }
    }

}
