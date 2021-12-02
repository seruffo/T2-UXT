
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class UnidadeVinculadaView : Enumeration
    {
        [DataMember]
        public static UnidadeVinculadaView Sim = new UnidadeVinculadaView('S', "Sim");
        [DataMember]
        public static UnidadeVinculadaView Nao = new UnidadeVinculadaView('N', "Não");
        public UnidadeVinculadaView(char? key, string displayName) : base(key, displayName) { }
    }

}
