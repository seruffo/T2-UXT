using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    [DataContract]
    public class InstrucaoViewModel : Base.Base
    {
        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Descricao { get; set; }
    }
}
