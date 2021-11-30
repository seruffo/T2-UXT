using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma
{
    public class TipoAtendimento : Enums<char?>
    {
        public static readonly TipoAtendimento Assistencial = new TipoAtendimento('1',"Saude");
        public static readonly TipoAtendimento Ocupacional = new TipoAtendimento('2', "Lazer");
        public static readonly TipoAtendimento Odontologico = new TipoAtendimento('3', "Assistência Social");
        public TipoAtendimento(char? key, string name) : base(key, name) { }
    }
}
