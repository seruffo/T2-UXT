using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class ExigeContrato : Enums<char?>
    {
        public static ExigeContrato Ambos = new ExigeContrato('A', "Ambos");
        public static ExigeContrato Fisica = new ExigeContrato('F', "Fisica");
        public static ExigeContrato Jurídica = new ExigeContrato('J', "Jurídica");
        public static ExigeContrato Nenhum = new ExigeContrato('N', "Nenhum");
        public ExigeContrato(char? key, string displayName) : base(key, displayName) { }
    }
}
