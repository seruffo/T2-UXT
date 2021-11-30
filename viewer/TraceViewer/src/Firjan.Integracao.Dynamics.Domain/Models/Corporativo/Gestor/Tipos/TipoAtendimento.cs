using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoAtendimento : Enums<char?>
    {
        public static readonly TipoAtendimento Saude = new TipoAtendimento('1',"Saude");
        public static readonly TipoAtendimento Lazer = new TipoAtendimento('2', "Lazer");
        public static readonly TipoAtendimento Odontologico = new TipoAtendimento('3', "Assist.Social");
        public TipoAtendimento(char? key, string name) : base(key, name) { }
    }
}
