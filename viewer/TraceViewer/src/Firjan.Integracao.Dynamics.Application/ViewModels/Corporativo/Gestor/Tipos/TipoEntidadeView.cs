using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class TipoEntidadeView : Enumeration
    {
        [DataMember]
        public static TipoEntidadeView Firjan = new TipoEntidadeView('1', "Firjan");
        [DataMember]
        public static TipoEntidadeView Sesi = new TipoEntidadeView('2', "Sesi");
        [DataMember]
        public static TipoEntidadeView Senai = new TipoEntidadeView('3', "Senai");
        public TipoEntidadeView(char? key, string displayName) : base(key, displayName) { }
    }
}
