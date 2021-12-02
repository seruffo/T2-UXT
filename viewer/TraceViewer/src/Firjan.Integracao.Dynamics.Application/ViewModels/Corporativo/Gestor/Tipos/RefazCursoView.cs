
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class RefazCursoView : Enumeration
    {
        [DataMember]
        public static RefazCursoView Sim = new RefazCursoView('S', "Sim");
        [DataMember]
        public static RefazCursoView nao = new RefazCursoView('N', "Não");
        public RefazCursoView(char? key, string displayName) : base(key, displayName) { }
    }

}
