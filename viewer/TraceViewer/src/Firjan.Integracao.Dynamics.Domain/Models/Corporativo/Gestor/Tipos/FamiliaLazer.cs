using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class FamiliaLazer : Enums<char?>
    {
        public static readonly FamiliaLazer Familiar = new FamiliaLazer('F', "Familiar");
        public static readonly FamiliaLazer Individual = new FamiliaLazer('I', "Individual");
        public static readonly FamiliaLazer Nenhum = new FamiliaLazer('N', "Nenhum");
        public FamiliaLazer(char? key, string name) : base(key, name) { }
    }
}
