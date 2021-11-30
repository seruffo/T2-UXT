using System;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using System.Runtime.Serialization;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.SGE;
using System.Collections.Generic;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto Produto"/>
    ///</summary>
    [DataContract]
    public class ProdutoViewModel : TipoViewModel<int>
    {
        ///<summary>
        ///Data da criação do serviço.
        ///</summary>
        [DataMember]
        public DateTime? Inicio { get; set; }
        ///<summary>
        ///Indica a data fim do servico.
        ///</summary>
        [DataMember]
        public DateTime? Fim { get; set; }
        ///<summary>
        ///Indica a data validade do servico.
        ///</summary>
        [DataMember]
        public DateTime? Validade { get; set; }
        ///<summary>
        ///Indica a data versao do servico.
        ///</summary>
        [DataMember]
        public DateTime? Versao { get; set; }
        ///<summary>
        ///Categoria do produto
        ///</summary>
        [DataMember]
        public Categoria Categoria { get; set; }
        ///<summary>
        ///Id da Classificação Serviço
        ///</summary>
        [DataMember]
        public int? ClassificacaoServicoId { get; set; }
        ///<summary>
        ///Classificação Serviço
        ///</summary>
        [DataMember]
        public ClassificacaoServicoViewModel ClassificacaoServico { get; set; }
        ///<summary>
        ///Código da Função servicço tecnológico
        ///</summary>
        [DataMember]
        public string FuncaoServicoTecnologicoCodigo { get; set; }
        ///<summary>
        ///Função Serviço tecnologico
        ///</summary>
        [DataMember]
        public FuncaoViewModel FuncaoServicoTecnologico { get; set; }
        ///<summary>
        ///Código do serviço
        ///</summary>
        [DataMember]
        public string CodigoServico { get; set; }
        ///<summary>
        ///Código da especialidade
        ///</summary>
        [DataMember]
        public string CodigoServicoEspecialidade { get; set; }
        ///<summary>
        ///Sinalizar os serviços que serão mostrados no Telemarketing.
        ///Atualmente os serviços de Educacao que estão sinalizados como
        ///divulgado, são os serviços considerados padrão, ou seja, o serviço
        ///que é oferecido pelo Sistema FIRJAN, sem ser personalizado para
        ///alguma empresa.
        ///</summary>
        [DataMember]
        public Divulgado Divulgado { get; set; }
        /// <summary>
        /// Armazenar a informação de divulgar serviço no site
        ///Inicialmente esse campo será utilizado para divulgaçãod e serviços
        ///de saude no site, que não são os mesmos que estao disponiveis para
        ///divulgação pelo telemarketing(ch_fg_divulgado_classifservofic)
        /// </summary>
        [DataMember]
        public Divulgado DivulgadoSite { get; set; }
        /// <summary>
        /// Código da especialidade que foi autorizada, pelo responsável, a ser realizada
        /// </summary>
        [DataMember]
        public int? GrupoClassificacaoId { get; set; }
        /// <summary>
        /// Especialidade que foi autorizada, pelo responsável, a ser realizada
        /// </summary>
        [DataMember]
        public GrupoClassificacaoViewModel GrupoClassificacao { get; set; }
        /// <summary>
        /// Codigo do primeiro nivel do grupo hierárquico (da tabela de servico)
        /// de um determinado servico
        /// </summary>
        [DataMember]
        public int? GrupoClassificacaoPrimeiroNivelId { get; set; }
        /// <summary>
        /// Primeiro nivel do grupo hierárquico (da tabela de servico)
        /// de um determinado servico
        /// </summary>
        [DataMember]
        public GrupoClassificacaoViewModel GrupoClassificacaoPrimeiroNivel { get; set; }
        /// <summary>
        /// Informa especialidadeou não S' - sim 'N' - não
        /// </summary>
        [DataMember]
        public Especialidade Especialidade { get; set; }
        /// <summary>
        /// Numero sequencial único responsável por gerar um identificador do registro.
        /// </summary>
        [DataMember]
        public int? LinhaServicoId { get; set; }
        /// <summary>
        /// Responsável por gerar um identificador do registro.
        /// </summary>
        [DataMember]
        public LinhaServicoViewModel LinhaServico { get; set; }
        [DataMember]
        public Int32? NivelServicoId { get; set; }
        [DataMember]
        public NivelServicoViewlModel NivelServico { get; set; }
        [DataMember]
        public string NomeResumido { get; set; }
        [DataMember]
        public int? PlataformaId { get; set; }
        [DataMember]
        public PlataformaViewModel Plataforma { get; set; }
        [DataMember]
        public int? ProdutoEspecialidadeId { get; set; }
        [DataMember]
        public ProdutoViewModel ProdutoEspecialidade { get; set; }
        [DataMember]
        public Int16? TabelaServicoId { get; set; }
        [DataMember]
        public TabelaServicoViewModel TabelaServico { get; set; }
        [DataMember]
        public int? TUSSId { get; set; }
        [DataMember]
        public TUSSViewModel TUSS { get; set; } 
        [DataMember]
        public string TipoEntidadeVinculoId { get; set; }
        [DataMember]
        public TipoEntidadeVinculoViewModel TipoEntidadeVinculo { get; set; }
        [DataMember]
        public char? TipoServicoId { get; set; }
        [DataMember]
        public TipoServicoViewModel TipoServico { get; set; }
        [DataMember]
        public ValeCultura ValeCultura { get; set; }
        [DataMember]
        public Dedutivel Dedutivel { get; set; }
        [DataMember]
        public string AreaId { get; set; }
        [DataMember]
        public AreaViewModel Area { get; set; }
        [DataMember]
        public LazerViewModel Lazer { get; set; }
        [DataMember]
        public SaudeViewModel Saude { get; set; }
        [DataMember]
        public Flag CursoPadrao { get; set; }
        [DataMember]
        public Byte? AreaDNId { get; set; }
        [DataMember]
        public AreaDNViewModel AreaDN { get; set; }
        [DataMember]
        public Int16? ModalidadeId { get; set; }
        [DataMember]
        public ModalidadeCursoViewModel Modalidade { get; set; }
        [DataMember]
        public Domain.Models.Corporativo.Gestor.Tipos.TipoCliente TipoCliente { get; set; }
        [DataMember]
        public Flag Atendimento { get; set; }
        [DataMember]
        public int ServicoOficialId { get; set; }
        [DataMember]
        public ServicoViewModel ServicoOficial { get; set; }
        [DataMember]
        public ExigeContrato ExigeConfeccaoContrato { get; set; }
        [DataMember]
        public string NumeroAgente { get; set; }
        [DataMember]
        public string CodigoSmais { get; set; }
        [DataMember]
        public bool? ExigeCPF { get; set; }
    }
}