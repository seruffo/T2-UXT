
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class GeraNumeroCertificado : Enums<char?>
    {
        public static GeraNumeroCertificado Sim = new GeraNumeroCertificado('S', "Sim");
        public static GeraNumeroCertificado Nao = new GeraNumeroCertificado('N', "Não");
        public GeraNumeroCertificado(char? key, string displayName) : base(key, displayName) { }
    }
}
