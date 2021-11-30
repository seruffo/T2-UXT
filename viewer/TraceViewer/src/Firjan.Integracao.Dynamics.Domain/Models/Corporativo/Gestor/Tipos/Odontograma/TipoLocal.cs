using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma
{
    public class TipoLocal : Enums<char?>
    {
        public static readonly TipoLocal UNOP = new TipoLocal('U', "UNOP");
        public static readonly TipoLocal UNMOVEL = new TipoLocal('2', "Unidade Móvel");
        public static readonly TipoLocal NOCLIENTE = new TipoLocal('3', "No Cliente");
        public TipoLocal(char? key, string name) : base(key, name) { }
    }
}
