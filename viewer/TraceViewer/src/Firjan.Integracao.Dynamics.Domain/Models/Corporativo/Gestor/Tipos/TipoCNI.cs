using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoCNI : Enums<char?>
    {
        public static readonly TipoCNI Identificado = new TipoCNI('1',"Contratante");
        public static readonly TipoCNI Planejado = new TipoCNI('2', "Contratado");
        public TipoCNI(char? key, string name) : base(key, name) { }
    }
}
