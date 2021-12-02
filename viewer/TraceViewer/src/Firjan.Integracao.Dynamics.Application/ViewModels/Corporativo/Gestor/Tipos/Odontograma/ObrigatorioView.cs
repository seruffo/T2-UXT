using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos.Odontograma
{    
    [DataContract]
    public class ObrigatorioView : Enums<char?>
    {
        [DataMember]
        public static ObrigatorioView Sim = new ObrigatorioView('S', "Sim");
        [DataMember]
        public static ObrigatorioView Nao = new ObrigatorioView('N', "Não");

        public ObrigatorioView(char? key, string displayName) : base(key, displayName) { }
    }
}
