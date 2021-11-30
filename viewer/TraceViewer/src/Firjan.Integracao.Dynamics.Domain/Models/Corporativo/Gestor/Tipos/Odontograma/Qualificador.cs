using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class Qualificador : Enums<char?>
    {
        public static readonly Qualificador Funcionario = new Qualificador('1',"Funcionário");
        public static readonly Qualificador Estagiario = new Qualificador('2', "Estagiário");
        public static readonly Qualificador AssessorExterno = new Qualificador('3', "Assessor Externo");
        public static readonly Qualificador Prestador = new Qualificador('4', "Prestador");
        public Qualificador(char? key, string name) : base(key, name) { }
    }
}
