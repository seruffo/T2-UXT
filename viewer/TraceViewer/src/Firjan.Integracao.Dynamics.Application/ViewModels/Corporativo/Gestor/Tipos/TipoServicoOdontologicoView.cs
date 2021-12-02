using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class TipoServicoOdontologicoView : Enumeration
    {
        [DataMember]
        public static TipoServicoOdontologicoView Inicial = new TipoServicoOdontologicoView('I', "Inicial");
        [DataMember]
        public static TipoServicoOdontologicoView Tratamento = new TipoServicoOdontologicoView('T', "Tratamento");
        [DataMember]
        public static TipoServicoOdontologicoView Urgencia = new TipoServicoOdontologicoView('U', "Urgênciaa");
        [DataMember]
        public static TipoServicoOdontologicoView Complementar = new TipoServicoOdontologicoView('C', "Complementar");
        [DataMember]
        public static TipoServicoOdontologicoView Saude = new TipoServicoOdontologicoView('P', "Pré-Agendamento");

        public TipoServicoOdontologicoView(char? key, string displayName) : base(key, displayName) { }
    }
}
