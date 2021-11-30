using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoServicoSaude : Enums<char?>
    {
        public static TipoServicoSaude Procedimento = new TipoServicoSaude('P', "Procedimento");
        public static TipoServicoSaude Consulta = new TipoServicoSaude('C', "Consulta");
        public static TipoServicoSaude Nenhum = new TipoServicoSaude('N', "Nenhum");
        public TipoServicoSaude(char? key, string displayName) : base(key, displayName) { }
    }

}
