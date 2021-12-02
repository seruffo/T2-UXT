using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class QtdDentesEnvolvidos : Enums<byte>
    {
        public static QtdDentesEnvolvidos Nenhum = new QtdDentesEnvolvidos(0, "Nenhum");
        public static QtdDentesEnvolvidos Um = new QtdDentesEnvolvidos(1, "Um dente");
        public static QtdDentesEnvolvidos MaisDeUm = new QtdDentesEnvolvidos(2, "Mais de Um");
        public static QtdDentesEnvolvidos NenhumEspecifico = new QtdDentesEnvolvidos(3, "Nenhum Específico");
        public QtdDentesEnvolvidos(byte key, string displayName) : base(key, displayName) { }
    }
}
