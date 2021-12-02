using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC
{
    public class Regiao : TipoModel<int>
    {
        public short? TipoRegiaoId { get; set; }
        public TipoRegiao TipoRegiao { get; set; }
        public int? EnderecoUnidadeId { get; set; }
        public EnderecoUnidade EnderecoUnidade { get; set; }
    }
}