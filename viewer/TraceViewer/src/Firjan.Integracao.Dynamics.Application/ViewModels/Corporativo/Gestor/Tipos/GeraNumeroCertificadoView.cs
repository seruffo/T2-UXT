
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class GeraNumeroCertificadoView : Enumeration
    {
        [DataMember]
        public static GeraNumeroCertificadoView Sim = new GeraNumeroCertificadoView('S', "Sim");
        [DataMember]
        public static GeraNumeroCertificadoView nao = new GeraNumeroCertificadoView('N', "Não");
        public GeraNumeroCertificadoView(char? key, string displayName) : base(key, displayName) { }
    }

}
