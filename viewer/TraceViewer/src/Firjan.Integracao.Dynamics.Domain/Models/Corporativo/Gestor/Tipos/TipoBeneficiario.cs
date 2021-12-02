using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoBeneficiario : Enums<char?>
    {
        public static readonly TipoBeneficiario Titular = new TipoBeneficiario('T',"Titular");
        public static readonly TipoBeneficiario Nao = new TipoBeneficiario('D', "Dependente");
        public TipoBeneficiario(char? key, string name) : base(key, name) { }
    }
}
