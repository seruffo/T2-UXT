
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoCliente : Enums<char?>
    {
        public static readonly TipoCliente Fisica = new TipoCliente('F', "Física");
        public static readonly TipoCliente Juridica = new TipoCliente('J', "Jurídica");
        public static readonly TipoCliente Ambos = new TipoCliente('A', "Ambos");
        public TipoCliente(char? key, string name) : base(key, name) { }
    }
}
