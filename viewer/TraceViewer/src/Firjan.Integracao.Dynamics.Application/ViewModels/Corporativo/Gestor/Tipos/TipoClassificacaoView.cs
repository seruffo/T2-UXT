using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class TipoClassificacaoView : Enumeration
    {
        [DataMember]
        public static TipoClassificacaoView MeioAmbiente = new TipoClassificacaoView('M', "Médico");
        [DataMember]
        public static TipoClassificacaoView AssistenciaSocial = new TipoClassificacaoView('O', "Odontológico");
        [DataMember]
        public static TipoClassificacaoView Educacao = new TipoClassificacaoView('E', "Educação em Saúde");
        [DataMember]
        public static TipoClassificacaoView Tecnologico = new TipoClassificacaoView('S', "Saúde Ocupacional");
        [DataMember]
        public static TipoClassificacaoView Cultura = new TipoClassificacaoView('T', "Segurança do Trabalho");
        public TipoClassificacaoView(char? key, string displayName) : base(key, displayName) { }
    }
}
