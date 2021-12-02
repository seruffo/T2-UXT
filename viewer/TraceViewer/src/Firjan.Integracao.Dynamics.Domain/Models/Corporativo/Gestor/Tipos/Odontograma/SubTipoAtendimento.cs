using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma
{
    public class SubTipoAtendimento : Enums<char?>
    {
        public static readonly SubTipoAtendimento Assistencial = new SubTipoAtendimento('1', "Assistencial");
        public static readonly SubTipoAtendimento Ocupacional = new SubTipoAtendimento('1', "Ocupacional");
        public static readonly SubTipoAtendimento Odontologico = new SubTipoAtendimento('3', "Saude");
        public static readonly SubTipoAtendimento Exame = new SubTipoAtendimento('4', "Exame");
        public static readonly SubTipoAtendimento Outros = new SubTipoAtendimento(null, "Outros");
        public SubTipoAtendimento(char? key, string name) : base(key, name) { }
    }
}
