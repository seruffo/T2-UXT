using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma
{
    public class AtendimentoOdontologico : TipoModel<string>
    {
        public DateTime Data { get; set; }
        public int PessoaId { get; set; } 
        public Pessoa Pessoa { get; set; }
        public Int16 NumeroSerie { get; set; }
        public SituacaoAtendimentoOdonto Situacao { get; set; }
        public Int16 UnidadeNegocioRegistraId { get; set; }
        public UnidadeNegocio UnidadeNegocioRegistra { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public DateTime Geracao { get; set; }
        public DateTime Digitacao { get; set; }
        public Colaborador Colaborador { get; set; }
        public DateTime InicioColaborador { get; set; }
        public TipoBeneficiario TipoBeneficiario { get; set; }
        public Entidade EntidadeAtendida { get; set; }
        public Int16 UnidadeNegocioUMOId { get; set; }
        public UnidadeNegocio UnidadeNegocioUMO { get; set; }
    }
}
