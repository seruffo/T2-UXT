using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class Contrato : TipoModel<Int16>
    {
        public Int16? UnidadeNegocioId { get; set; }
        public UnidadeNegocio UnidadeNegocio { get; set; }
        public Int16? TipoContratoId { get; set; }
        public TipoContrato TipoContrato { get; set; }
        public string Numero { get; set; }
        public DateTime Assinatura { get; set; }
        public DateTime Vigencia { get; set; }
        public DateTime Final { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public TodasUnidadesNegocios TodasUnidadesNegocios { get; set; }
        public TodosServicos TodosServicos { get; set; }
        public DateTime Cancelamento { get; set; }
        public TodasPessoas TodasPessoas { get; set; }
        public DateTime Rescisao { get; set; }
        public string NumeroProcesso { get; set; }
        public TipoCNI TipoCNI { get; set; }
        public string NumeroTermo { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Alteracao { get; set; }
        public int NumeroUltimaNegociacao { get; set; }
        public Int16? UnidadeNegocioExecutoraUltimaNegociacaoId { get; set; }
        public UnidadeNegocio UnidadeNegocioExecutoraUltimaNegociacao { get; set; }
        public int NumeroUltimaSituacaoCobranca { get; set; }
        public Int16? UnidadeNegocioUltimaSituacaoCobrancaId { get; set; }
        public UnidadeNegocio UnidadeNegocioUltimaSituacaoCobranca { get; set; }
        public string NumeroUltimoAditivoContrato { get; set; }        
    }
}
