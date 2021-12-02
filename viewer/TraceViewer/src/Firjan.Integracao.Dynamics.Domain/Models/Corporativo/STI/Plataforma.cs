using Firjan.Integracao.Dynamics.Domain.Models.Base;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI
{
    public class Plataforma : TipoModel<int>
    {
        public string CodigoArea { get; set; }
        public Area Area { get; set; }
    }
}