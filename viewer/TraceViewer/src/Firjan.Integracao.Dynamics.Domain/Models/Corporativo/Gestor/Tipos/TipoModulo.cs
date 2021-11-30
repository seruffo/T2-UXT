using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoModulo : Enums<char?>
    {
        public static TipoModulo Presencial = new TipoModulo('P', "Presencial");
        public static TipoModulo Distancia = new TipoModulo('D', "Distancia");
        public static TipoModulo Web = new TipoModulo('W', "Web");
        public static TipoModulo Movel = new TipoModulo('M', "Movel");
        public TipoModulo(char? key, string displayName) : base(key, displayName) { }
    }
}
