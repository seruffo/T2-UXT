using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC
{
    public class RegiaoUnidadeNegocio : Base.Base
    {
        public Int16? TipoRegiaoId { get; set; }
        public TipoRegiao TipoRegiao { get; set; }
        public int? RegiaoId { get; set; }
        public Regiao Regiao { get; set; }
        public Int16? UnidadeNegocioId { get; set; }
        public UnidadeNegocio UnidadeNegocio { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }
    }
}