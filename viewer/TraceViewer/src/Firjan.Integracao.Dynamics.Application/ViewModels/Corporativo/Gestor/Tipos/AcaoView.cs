using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class AcaoView : Enums<char?>
    {
        [DataMember]
        public static AcaoView Direta = new AcaoView('D', "Direta");
        [DataMember]
        public static AcaoView Indireta = new AcaoView('I', "Indireta");
        public AcaoView(char? key, string name) : base(key, name) { }
    }
}
