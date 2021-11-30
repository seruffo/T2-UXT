using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoRegimento : Enums<char?>
    {
        public static TipoRegimento Regimental = new TipoRegimento('1', "Regimental");
        public static TipoRegimento NaoRegimental = new TipoRegimento('2', "Não Regimental");
        public TipoRegimento(char? key, string displayName) : base(key, displayName) { }
    }
}
