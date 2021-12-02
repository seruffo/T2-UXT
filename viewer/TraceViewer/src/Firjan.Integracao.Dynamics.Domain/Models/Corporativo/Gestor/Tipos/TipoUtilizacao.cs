using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoUtilizacao : Enums<char?>
    {
        public static TipoUtilizacao Saude = new TipoUtilizacao('1', "Sistema de Saude");
        public static TipoUtilizacao SCA = new TipoUtilizacao('2', "SCA");
        public TipoUtilizacao(char? key, string displayName) : base(key, displayName) { }
    }
}
