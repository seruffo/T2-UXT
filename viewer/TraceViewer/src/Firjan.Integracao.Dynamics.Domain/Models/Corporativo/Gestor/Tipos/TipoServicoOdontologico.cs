using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoServicoOdontologico : Enums<char?>
    {
        public static TipoServicoOdontologico Inicial = new TipoServicoOdontologico('I', "Inicial");
        public static TipoServicoOdontologico Tratamento = new TipoServicoOdontologico('T', "Tratamento");
        public static TipoServicoOdontologico Urgencia = new TipoServicoOdontologico('U', "Urgência");
        public static TipoServicoOdontologico Complementar = new TipoServicoOdontologico('C', "Complementar");
        public TipoServicoOdontologico(char? key, string displayName) : base(key, displayName) { }
    }
}
