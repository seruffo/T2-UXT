using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma
{
    public class TipoConvenio : Enums<char?>
    {
        public static readonly TipoConvenio Consulta = new TipoConvenio('P',"Particular");
        public static readonly TipoConvenio Reconsulta = new TipoConvenio('C', "Convenio");
        public TipoConvenio(char? key, string name) : base(key, name) { }
    }
}
