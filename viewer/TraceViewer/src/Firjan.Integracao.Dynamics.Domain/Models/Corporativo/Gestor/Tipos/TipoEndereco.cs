using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoEndereco : Enums<char?>
    {
        public static TipoEndereco Presencial = new TipoEndereco('P', "Proprio");
        public static TipoEndereco Distancia = new TipoEndereco('D', "Divulgado");
        public static TipoEndereco Web = new TipoEndereco('A', "Ambos");
        public static TipoEndereco Movel = new TipoEndereco('N', "Nenhum");
        public TipoEndereco(char? key, string displayName) : base(key, displayName) { }
    }
}
