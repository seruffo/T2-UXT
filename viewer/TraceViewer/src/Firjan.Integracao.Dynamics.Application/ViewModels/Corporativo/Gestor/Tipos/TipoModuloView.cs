using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class TipoModuloView : Enumeration
    {
        [DataMember]
        public static TipoModuloView Presencial = new TipoModuloView('P', "Presencial");
        [DataMember]
        public static TipoModuloView Distancia = new TipoModuloView('D', "Distancia");
        [DataMember]
        public static TipoModuloView Web = new TipoModuloView('W', "Web");
        [DataMember]
        public static TipoModuloView Movel = new TipoModuloView('M', "Movel");
        public TipoModuloView(char? key, string displayName) : base(key, displayName) { }
    }
}
