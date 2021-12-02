using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoConsulta : Enums<char?>
    {
        public static readonly TipoConsulta Consulta = new TipoConsulta('C',"Consulta");
        public static readonly TipoConsulta Reconsulta = new TipoConsulta('R', "Reconsulta");
        public TipoConsulta(char? key, string name) : base(key, name) { }
    }
}
