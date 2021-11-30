using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class ValeCulturaView : Enumeration
    {
        [DataMember]
        public static ValeCulturaView Sim = new ValeCulturaView('S', "Sim");
        [DataMember]
        public static ValeCulturaView Nao = new ValeCulturaView('N', "Não");
        public ValeCulturaView(char? key, string displayName) : base(key, displayName) { }
    }

}
