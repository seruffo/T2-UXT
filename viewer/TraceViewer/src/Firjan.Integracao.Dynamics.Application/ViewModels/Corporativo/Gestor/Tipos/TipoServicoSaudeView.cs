using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class TipoServicoSaudeView : Enums<char?>
    {
        [DataMember]
        public static TipoServicoSaudeView MeioAmbiente = new TipoServicoSaudeView('P', "Procedimento");
        [DataMember]
        public static TipoServicoSaudeView AssistenciaSocial = new TipoServicoSaudeView('C', "Consulta");
        [DataMember]
        public static TipoServicoSaudeView Educacao = new TipoServicoSaudeView('N', "Nenhum");
        public TipoServicoSaudeView(char? key, string displayName) : base(key, displayName) { }
    }
}
