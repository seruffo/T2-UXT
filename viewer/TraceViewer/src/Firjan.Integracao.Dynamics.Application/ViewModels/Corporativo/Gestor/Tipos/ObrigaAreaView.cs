
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class ObrigaAreaView : Enumeration
    {
        [DataMember]
        public static ObrigaAreaView Sim = new ObrigaAreaView('S', "Sim");
        [DataMember]
        public static ObrigaAreaView nao = new ObrigaAreaView('N', "Não");
        public ObrigaAreaView(char? key, string displayName) : base(key, displayName) { }
    }

}
