using Firjan.Integracao.Dynamics.Domain.Models.Base;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class Instrucao : TipoModel<char>
    {
        public char Codigo { get; set; }
    }
}
