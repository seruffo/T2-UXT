using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoEntidade : Enums<char?>
    {
        public static TipoEntidade Firjan = new TipoEntidade('1', "Firjan");
        public static TipoEntidade Sesi = new TipoEntidade('2', "Sesi");
        public static TipoEntidade Senai = new TipoEntidade('3', "Senai");
        public static TipoEntidade IEL = new TipoEntidade('4', "IEL");
        public static TipoEntidade CIRJ = new TipoEntidade('5', "CIRJ");
        public TipoEntidade(char? key, string displayName) : base(key, displayName) { }
    }
}
