using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoClassificacao : Enums<char?>
    {
        public static TipoClassificacao MeioAmbiente = new TipoClassificacao('M', "Médico");
        public static TipoClassificacao AssistenciaSocial = new TipoClassificacao('O', "Odontológico");
        public static TipoClassificacao Educacao = new TipoClassificacao('E', "Educação em Saúde");
        public static TipoClassificacao Tecnologico = new TipoClassificacao('S', "Saúde Ocupacional");
        public static TipoClassificacao Cultura = new TipoClassificacao('T', "Segurança do Trabalho");
        public TipoClassificacao(char? key, string displayName) : base(key, displayName) { }
    }
}
