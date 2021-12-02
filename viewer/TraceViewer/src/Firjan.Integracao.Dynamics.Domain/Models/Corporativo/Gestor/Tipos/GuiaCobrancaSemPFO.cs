using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class GuiaCobrancaSemPFO : Enums<char?>
    {
        public static GuiaCobrancaSemPFO Sim = new GuiaCobrancaSemPFO('S', "Sim");
        public static GuiaCobrancaSemPFO Nao = new GuiaCobrancaSemPFO('N', "Não");
        public GuiaCobrancaSemPFO(char? key, string displayName) : base(key, displayName) { }
    }
}
