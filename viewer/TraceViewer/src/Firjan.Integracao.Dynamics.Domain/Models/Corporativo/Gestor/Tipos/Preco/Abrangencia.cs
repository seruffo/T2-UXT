using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class Abrangencia : Enumeration
    {
        public static readonly Abrangencia Unidade = new Abrangencia('U', "Unidade");
        public static readonly Abrangencia Regional = new Abrangencia('R', "Regional");
        public static readonly Abrangencia Estadual = new Abrangencia('E', "Estadual");
        public Abrangencia(char? key, string displayName) : base(key, displayName) { }
    }
}
