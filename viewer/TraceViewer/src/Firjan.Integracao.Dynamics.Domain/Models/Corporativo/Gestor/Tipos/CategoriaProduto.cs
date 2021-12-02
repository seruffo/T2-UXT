using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class Categoria : Enums<char?>
    {
        public static Categoria Material = new Categoria('M', "Material");
        public static Categoria Pacote = new Categoria('P', "Pacote");
        public static Categoria Grupo = new Categoria('G', "Grupo");
        public static Categoria Servicos = new Categoria('S', "Servicos");
        public Categoria(char? key, string displayName) : base(key, displayName) { }
    }
}
