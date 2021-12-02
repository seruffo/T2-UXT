using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    [DataContract]
    public class EstadoView : Enums<char?>
    {
        [DataMember]
        public static EstadoView Estudo = new EstadoView('E', "Estudo");
        [DataMember]
        public static EstadoView Aprovado = new EstadoView('A', "Aprovado");
        [DataMember]
        public static EstadoView NaoAprovado = new EstadoView('N', "Não Aprovado");
        public EstadoView(char? key, string displayName) : base(key, displayName) { }
    }
}
