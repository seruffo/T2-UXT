using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using System;
using System.Collections.Generic;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class GrupoClassificacao : TipoModel<int>
    {
        public new string Descricao { get; set; }
        public string Nome { get; set; }
        public bool? NovaInterface { get; set; }
        public char? TipoServicoId { get; set; }
        public TipoServico TipoServico { get; set; }
        public DateTime? Fim { get; set; }
        public string NumeroOrdem { get; set; }
        public NivelGrupo NivelServico { get; set; }
        public bool? PrimeiroNivelServico { get; set; }
        public string CodigoTipoEntidadeVinculo { get; set; }
        public TipoEntidadeVinculo TipoEntidadeVinculo { get; set; }
        public IndicadorProduto IndicadorProduto { get; set; }
        public int? GrupoClassificacaoPaiId { get; set; }
        public GrupoClassificacao GrupoClassificacaoPai { get; set; }
        public IEnumerable<GrupoClassificacao> GruposClassificacoes { get; set; }
        public string Logon { get; set; }
    }
}
