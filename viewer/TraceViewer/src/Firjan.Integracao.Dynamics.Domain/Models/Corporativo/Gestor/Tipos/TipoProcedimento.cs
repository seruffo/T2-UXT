using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{ 

    public class TipoProcedimento : Enums<char?>
    {
        public static TipoProcedimento MeioAmbiente = new TipoProcedimento('D', "Diagnóstico");
        public static TipoProcedimento AssistenciaSocial = new TipoProcedimento('C', "Cirúrgicos");
        public static TipoProcedimento Educacao = new TipoProcedimento('T', "Terapia");
        public static TipoProcedimento MudancaFuncao = new TipoProcedimento('O', "Complementar");
        public static TipoProcedimento Nenhum = new TipoProcedimento('N', "Nenhum");
        public TipoProcedimento(char? key, string displayName) : base(key, displayName) { }
    }
}
