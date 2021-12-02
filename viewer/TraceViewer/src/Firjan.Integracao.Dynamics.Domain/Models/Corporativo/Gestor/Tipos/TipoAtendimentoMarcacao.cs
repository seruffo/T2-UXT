using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoAtendimentoMarcacao : Enums<char?>
    {
        public static readonly TipoAtendimentoMarcacao Unidade = new TipoAtendimentoMarcacao('U',"Unidade");
        public static readonly TipoAtendimentoMarcacao Nao = new TipoAtendimentoMarcacao('N', "Telefônico");
        public TipoAtendimentoMarcacao(char? key, string name) : base(key, name) { }
    }
}
