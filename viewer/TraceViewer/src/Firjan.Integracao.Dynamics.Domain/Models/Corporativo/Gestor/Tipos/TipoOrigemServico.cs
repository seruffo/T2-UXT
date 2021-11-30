using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoOrigemServico : Enums<char?>
    {
        public static TipoOrigemServico MeioAmbiente = new TipoOrigemServico('1', "Admissional");
        public static TipoOrigemServico AssistenciaSocial = new TipoOrigemServico('2', "Periódico");
        public static TipoOrigemServico Educacao = new TipoOrigemServico('3', "Retorno ao trabalho");
        public static TipoOrigemServico MudancaFuncao = new TipoOrigemServico('4', "Mudança de Função");
        public static TipoOrigemServico Demissional = new TipoOrigemServico('5', "Demissional");
        public TipoOrigemServico(char? key, string displayName) : base(key, displayName) { }
    }
}
