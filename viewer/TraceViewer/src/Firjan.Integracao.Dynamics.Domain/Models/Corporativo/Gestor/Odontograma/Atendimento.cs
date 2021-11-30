using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma
{
    public class Atendimento : TipoModel<string>
    {
        public DateTime? Data { get; set; }
        public Int16 Numero { get; set; }
        public int ColaboradorAtendeId { get; set; }
        public Colaborador ColaboradorAtende { get; set; }
        public DateTime? InicioColaborador { get; set; }
        public int TipoFichaId { get; set; }
        public TipoFicha TipoFicha { get; set; }
        public Int16? UnidadeNegocioRecebeId { get; set; }
        public UnidadeNegocio UnidadeNegocioRecebe { get; set; }
        public Int16 UnidadeNegocioRegistraId { get; set; }
        public UnidadeNegocio UnidadeNegocioRegistra { get; set; }
        public int? EntidadePrestadoraId { get; set; }
        public int? EntidadeAtendidaId { get; set; }
        public SituacaoAtendimento Situacao { get; set; }
        public DateTime? Geracao { get; set; }
        public Tipos.TipoAtendimento TipoAtendimento { get; set; }
        public DateTime? Digitacao { get; set; }
        public DateTime? Pagamento { get; set; }
        public Assistencial Assistencial { get; set; }
        public int? PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public Tipos.TipoRegimento QualificadorBeneficiario { get; set; }
        public TipoBeneficiario TipoBeneficiario { get; set; }
        public TipoConvenio TipoConvenio { get; set; }
        public int? ColaboradorResponsavelId { get; set; }
        public Colaborador ColaboradorResponsavel { get; set; }
        public DateTime? InicioColaboradorResponsavel { get; set; }
        public SubTipoAtendimento SubTipoAtendimento { get; set; }
        public TipoSerieAtendimento TipoSerieAtendimento { get; set; }
        public StatusSede StatusSede { get; set; }
        public MarcadoAtendimento MarcadoAtendimento { get; set; }
        public string NumeroBoleto { get; set; }
        public string JustificativaFaltaProfissionalAtendimento { get; set; }
        public TipoUtilizacao TipoUtilizacao { get; set; }
        public Deficiencia Deficiencia { get; set; }
        public Int16? UnidadeNegocioEmitenteId { get; set; }
        public UnidadeNegocio UnidadeNegocioEmitente { get; set; }
        public TipoLocal TipoLocal { get; set; }
        public string AtendimentorelacionadoId { get; set; }
        public Atendimento Atendimentorelacionado { get; set; }
        public bool? AptoAltura { get; set; }
        public bool? AptoConfinamento { get; set; }
        public Int16? UnidadeNegocioContratoId { get; set; }
        public UnidadeNegocio UnidadeNegocioContrato { get; set; }
        public Int16? ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        public DateTime? MudancaSede { get; set; }
    }
}
