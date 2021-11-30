
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    [KnownType(typeof(FlagView))]
    public class CustoSistemaView : Enumeration
    {
        [DataMember]
        public static CustoSistemaView Sim = new CustoSistemaView('S', "Sim");
        [DataMember]
        public static CustoSistemaView nao = new CustoSistemaView('N', "Não");
        public CustoSistemaView(char? key, string displayName) : base(key, displayName) { }
    }
}
