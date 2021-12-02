using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoEntidadeVinculo : Enums<string>
    {
        public static TipoEntidadeVinculo CIRJ = new TipoEntidadeVinculo("8", "CIRJ");
        public static TipoEntidadeVinculo FEDERACAO = new TipoEntidadeVinculo("5", "FEDERACAO");
        public static TipoEntidadeVinculo IEL = new TipoEntidadeVinculo("9", "IEL");
        public static TipoEntidadeVinculo SENAI = new TipoEntidadeVinculo("14", "SENAI-DR");
        public static TipoEntidadeVinculo SESI = new TipoEntidadeVinculo("12", "SESI-DR");
        public TipoEntidadeVinculo(string key, string displayName) : base(key, displayName) { }
        public bool IsIdEqualTo(string compareTo)
        {
            return (Id.Equals(compareTo));
        }
    }
}
