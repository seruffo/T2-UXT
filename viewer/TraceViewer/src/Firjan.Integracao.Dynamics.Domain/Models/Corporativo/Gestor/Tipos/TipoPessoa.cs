using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoPessoa : Enums<char?>
    {
        public static readonly TipoPessoa Fisica = new TipoPessoa('F',"Física");
        public static readonly TipoPessoa Juridica = new TipoPessoa('J', "Jurídica");
        public static readonly TipoPessoa Ambos = new TipoPessoa('A', "Ambos");
        public TipoPessoa(char? key, string name) : base(key, name) { }
    }
}
