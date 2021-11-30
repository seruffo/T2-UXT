using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    [DataContract]
    public class GuiaCobrancaSemPFOView : Enumeration
    {
        [DataMember]
        public static GuiaCobrancaSemPFOView Sim = new GuiaCobrancaSemPFOView('S', "Sim");
        [DataMember]
        public static GuiaCobrancaSemPFOView Nao = new GuiaCobrancaSemPFOView('N', "Não");
        public GuiaCobrancaSemPFOView(char? key, string displayName) : base(key, displayName) { }
    }
}
