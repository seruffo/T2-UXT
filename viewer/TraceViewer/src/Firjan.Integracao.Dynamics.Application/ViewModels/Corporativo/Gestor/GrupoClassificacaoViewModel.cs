
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{ 
    [DataContract]
    public class GrupoClassificacaoViewModel : TipoViewModel<int>
    {
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public bool? NovaInterface { get; set; }
        [DataMember]
        public EspecialidadeView Especialidade { get; set; }
        [DataMember]
        public TipoServicoViewModel TipoServico { get; set; }
        [DataMember]
        public DateTime? Fim { get; set; }
        [DataMember]
        public string NumeroOrdem { get; set; }
        [DataMember]
        public NivelGrupo NivelServico { get; set; }
        [DataMember]
        public string CodigoTipoEntidadeVinculo { get; set; }
        [DataMember]
        public TipoEntidadeVinculoViewModel TipoEntidadeVinculo { get; set; }
        [DataMember]
        public IndicadorProduto IndicadorProduto { get; set; }
        [DataMember]
        public int? GrupoClassificacaoPaiId { get; set; }
        [DataMember]
        public GrupoClassificacaoViewModel GrupoClassificacaoPai { get; set; }
        [DataMember]
        public ICollection<GrupoClassificacaoViewModel> GruposClassificacoes { get; set; }
        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<ProdutoViewModel> Produtos { get; set; }
    }
}
