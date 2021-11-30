using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class TipoProcedimentoView : Enums<char?>
    {
        [DataMember]
        public static TipoProcedimentoView MeioAmbiente = new TipoProcedimentoView('D', "Diagnóstico");
        [DataMember]
        public static TipoProcedimentoView AssistenciaSocial = new TipoProcedimentoView('C', "Cirúrgicos");
        [DataMember]
        public static TipoProcedimentoView Educacao = new TipoProcedimentoView('T', "Terapia");
        [DataMember]
        public static TipoProcedimentoView MudancaFuncao = new TipoProcedimentoView('O', "Complementar");
        [DataMember]
        public static TipoProcedimentoView Nenhum = new TipoProcedimentoView('N', "Nenhum");
        public TipoProcedimentoView(char? key, string displayName) : base(key, displayName) { }
    }
}
