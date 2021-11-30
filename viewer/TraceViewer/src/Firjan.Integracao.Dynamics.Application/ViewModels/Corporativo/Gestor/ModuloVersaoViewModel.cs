using System;
using System.Runtime.Serialization;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    [DataContract]
    public class ModuloVersaoViewModel : Base.Base
    {
        ///<summary>
        ///Atributo sequencial que identifica um um produto educacional.
        ///Identifica um serviço que será prestado para área de educação
        ///Ex: 1
        ///</summary>
        [DataMember]
        public string Codigo { get; set; } = null;
        ///<summary>
        ///Código do arquivo que contém o conteúdo programático da versao de um módulo.
        ///Ex.: \ap\ensino\conteudo\0122203.doc
        ///</summary>
        [DataMember]
        public string Descricao { get; set; } = null;
        ///<summary>
        ///Atributo que identifica o número da versão do módulo de um
        ///produto educacional.Identifica um serviço que será prestado para área de educação.
        ///Ex: 1
        ///</summary>
        [DataMember]
        public string NumeroVersao { get; set; } = null;
        /// <summary>
        /// Carga horária total da versao do módulo
        /// </summary>
        [DataMember]
        public Int16? QtdHoras { get; set; }
        /// <summary>
        /// Data fim da versão do módulo
        /// </summary>
        [DataMember]
        public DateTime? Fim { get; set; }
        /// <summary>
        /// Código do grau de Instrução
        /// Ex: 2, 3, 5
        /// </summary>
        [DataMember]
        public string CodigoInstrucao { get; set; }
        /// <summary>
        /// Grau de Instrução
        /// </summary>
        [DataMember]
        public InstrucaoViewModel Instrucao { get; set; }
        /// <summary>
        /// Número sequencial que identifica um tipo de modalidade
        /// </summary>
        [DataMember]
        public Int16? TipoModalidadeId { get; set; }
        /// <summary>
        /// Tipo de modalidade
        /// </summary>
        [DataMember]
        public TipoModalidadeViewModel TipoModalidade { get; set; }
        /// <summary>
        /// Carga horária total do estágio do módulo
        /// </summary>
        [DataMember]
        public Int16? QtdHorasEstagio { get; set; }
        /// <summary>
        /// Fag Tipo Módulo: (P) Presencial, (D) à distancia, (W) Web, (M) Móvel
        /// </summary>
        [DataMember]
        public TipoModulo TipoModulo { get; set; }
        /// <summary>
        /// Fag Gera número certificado: (S) Sim, (N) Não
        /// </summary>
        [DataMember]
        public GeraNumeroCertificado GeraNumeroCertificado { get; set; }
        /// <summary>
        /// Fag Contém ou Não disciplina: (S) Sim, (N) Não
        /// </summary>
        [DataMember]
        public ContemDisciplina ContemDisciplina { get; set; }
        /// <summary>
        /// Sequencial do Produto
        /// </summary>
        [DataMember]
        public int? ProdutoId { get; set; }
        /// <summary>
        /// Produto
        /// </summary>
        [DataMember]
        public ProdutoViewModel Produto { get; set; }
        /// <summary>
        /// Nome do modulo versão 
        /// Este atributo é originado ServicoOficial
        /// </summary>
        [DataMember]
        public string Nome { get; set; }
        /// <summary>
        /// Nome resumido
        /// Este atributo é originado ServicoOficial
        /// </summary>
        [DataMember]
        public string NomeResumido { get; set; }
        /// <summary>
        /// Data de início do modulo versão
        /// </summary>
        [DataMember]
        public DateTime Inicio { get; set; }
        /// <summary>
        /// Código sequencial que identifica o portifolio.
        /// </summary>
        [DataMember]
        public int? PortifolioEducacaoId { get; set; }
        /// <summary>
        /// Portifolio.
        /// </summary>
        [DataMember]
        public PortifolioEducacaoViewModel PortifolioEducacao { get; set; }
        /// <summary>
        /// Indica se o modulo versao aceita processo seletivo
        /// </summary>
        [DataMember]
        public bool FlagProcessoSeletivo { get; set; }
        /// <summary>
        /// Custo informado em sistema
        /// </summary>
        [DataMember]
        public CustoSistema CustoSistema { get; set; }
        /// <summary>
        /// Quantidade de máxima de dias em que a versão do módulo deve ser concluida
        /// </summary>
        [DataMember]
        public Int16? QtddDias { get; set; }
        /// <summary>
        /// Atributo indicador se o moduloversao pode ser cursado novamente,
        /// independente do estado do aluno(Concluído, Evadido, Eliminado, etc.)
        /// </summary>
        [DataMember]
        public RefazCurso RefazCurso { get; set; }
        /// <summary>
        /// Idade mínima exigida para os participantes
        /// Ex: 14 anos
        /// </summary>
        [DataMember]
        public Byte IdadeMinimaEducacao { get; set; }
        /// <summary>
        /// Idade máxima exigida para os participantes
        /// Ex: 21 anos
        /// </summary>
        [DataMember]
        public Byte IdadeMaximaEducacao { get; set; }
        /// <summary>
        /// Idade máxima exigida para os participantes
        /// Ex: 21 anos
        /// </summary>
        [DataMember]
        public string Missao { get; set; }
    }
}
