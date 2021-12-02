using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class EspecialidadeView : Enumeration
    {
        [DataMember]
        public static EspecialidadeView Sim = new EspecialidadeView('S', "Sim");
        [DataMember]
        public static EspecialidadeView Nao = new EspecialidadeView('N', "Não");
        public EspecialidadeView(char? key, string displayName) : base(key, displayName) { }
    }
}
