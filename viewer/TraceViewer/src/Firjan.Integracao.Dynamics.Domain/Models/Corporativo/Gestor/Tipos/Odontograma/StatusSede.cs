using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class StatusSede : Enums<char?>
    {
        public static readonly StatusSede Funcionario = new StatusSede('0', "Sem pendência");
        public static readonly StatusSede Estagiario = new StatusSede('1', "Aguardando Atualizar Sede");
        public static readonly StatusSede AssessorExterno = new StatusSede('2', "Atualizado na Sede");
        public StatusSede(char? key, string name) : base(key, name) { }
    }
}
