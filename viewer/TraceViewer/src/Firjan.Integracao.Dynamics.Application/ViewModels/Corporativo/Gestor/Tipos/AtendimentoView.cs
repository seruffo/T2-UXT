using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class AtendimentoView : Enums<char>
    {
        [DataMember]
        public static AtendimentoView Sim = new AtendimentoView('S', "Sim");
        [DataMember]
        public static AtendimentoView Nao = new AtendimentoView('N', "Não");
        public AtendimentoView(char key, string displayName) : base(key, displayName) { }
    }

}
