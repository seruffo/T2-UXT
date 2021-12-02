using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoPreenchimento : Enums<char?>
    {
        public static readonly TipoPreenchimento Obrigatorio = new TipoPreenchimento('S', "Preenchimento Obrigatorio");
        public static readonly TipoPreenchimento NaoPode = new TipoPreenchimento('N', "Não pode preencher");
        public static readonly TipoPreenchimento Opcional = new TipoPreenchimento('O', "Preenchimento Opcional");
        public TipoPreenchimento(char? key, string name) : base(key, name) { }
    }
}
