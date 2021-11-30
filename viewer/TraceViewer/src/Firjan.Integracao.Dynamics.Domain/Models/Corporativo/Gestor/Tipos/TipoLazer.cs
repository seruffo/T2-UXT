using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoLazer : Enums<char?>
    {
        public static readonly TipoLazer SESI = new TipoLazer('S', "SESI");
        public static readonly TipoLazer Eventos = new TipoLazer('E', "Eventos");
        public static readonly TipoLazer Cabnas = new TipoLazer('A', "Cabanas");
        public static readonly TipoLazer Formativa = new TipoLazer('F', "Formativa");
        public TipoLazer(char? key, string name) : base(key, name) { }
    }
}
