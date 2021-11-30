using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos.Base
{
    [DataContract]
    [KnownType(typeof(CustoSistemaView))]
    public class FlagView : Enumeration
    {
        [DataMember]
        public static FlagView Sim = new FlagView('S',"Sim");
        [DataMember]
        public static FlagView nao = new FlagView('N', "Não");
        public FlagView(char? key, string displayName) : base(key, displayName) { }
    }
}
