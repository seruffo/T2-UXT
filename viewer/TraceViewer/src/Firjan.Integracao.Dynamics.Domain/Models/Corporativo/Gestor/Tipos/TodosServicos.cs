using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TodosServicos : Enums<char?>
    {
        public static TodosServicos Sim = new TodosServicos('S', "Sim");
        public static TodosServicos Nao = new TodosServicos('N', "Não");
        public TodosServicos(char? key, string displayName) : base(key, displayName) { }
    }
}
