using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class ContemDisciplina : Enums<char?>
    {
        public static ContemDisciplina Sim = new ContemDisciplina('S', "Sim");
        public static ContemDisciplina Nao = new ContemDisciplina('N', "Não");
        public ContemDisciplina(char? key, string displayName) : base(key, displayName) { }
    }
}
