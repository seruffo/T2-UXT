using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Odontograma;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma
{
    [DataContract]
    public class SaudeFiguraOdontogramaViewModel : Application.ViewModels.Corporativo.Base.Base
    {
        [DataMember]
        public int SaudeId { get; set; }
        [DataMember]
        public SaudeViewModel Saude { get; set; }
        [DataMember]
        public int? FiguraOdontogramaId { get; set; }
        [DataMember]
        public FiguraOdontogramaViewModel FiguraOdontograma { get; set; }
    }
}
