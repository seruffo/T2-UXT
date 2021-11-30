using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class ContemDisciplinaView : Enumeration
    {
        [DataMember]
        public static ContemDisciplinaView Sim = new ContemDisciplinaView('S', "Sim");
        [DataMember]
        public static ContemDisciplinaView nao = new ContemDisciplinaView('N', "Não");
        public ContemDisciplinaView(char? key, string displayName) : base(key, displayName) { }
    }
}
