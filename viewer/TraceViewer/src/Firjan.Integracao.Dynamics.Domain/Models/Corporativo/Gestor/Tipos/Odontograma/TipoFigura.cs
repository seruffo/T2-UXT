
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma
{
    public class TipoFigura : Enums<char?>
    {
        public static readonly TipoFigura Planejado = new TipoFigura('P',"Planejado");
        public static readonly TipoFigura RealizadoSESI = new TipoFigura('R', "Realizado no SESI");
        public static readonly TipoFigura RealizadoForaSESI = new TipoFigura('I', "Realizado fora do SESI");
        public TipoFigura(char? key, string name) : base(key, name) { }
    }
}
