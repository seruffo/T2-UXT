using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TodasUnidadesNegocios : Enums<char?>
    {
        public static TodasUnidadesNegocios Sim = new TodasUnidadesNegocios('S', "Sim");
        public static TodasUnidadesNegocios Nao = new TodasUnidadesNegocios('N', "Não");
        public TodasUnidadesNegocios(char? key, string displayName) : base(key, displayName) { }
    }
}
