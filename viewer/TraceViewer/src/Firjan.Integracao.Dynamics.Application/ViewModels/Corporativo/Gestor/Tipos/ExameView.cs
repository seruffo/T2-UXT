
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class ExameView : Enums<char?>
    {
        [DataMember]
        public static ExameView Sim = new ExameView('S', "Sim");
        [DataMember]
        public static ExameView Nao = new ExameView('N', "Não");
        public ExameView(char? key, string displayName) : base(key, displayName) { }
    }
}
