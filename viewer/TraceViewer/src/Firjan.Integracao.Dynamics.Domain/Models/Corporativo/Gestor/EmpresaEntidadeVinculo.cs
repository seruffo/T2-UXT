namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class EmpresaEntidadeVinculo : Base.Base
    {
        public string TipoEntidadeVinculoId { get; set; }
        public TipoEntidadeVinculo TipoEntidadeVinculo { get; set; }

        public string EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
