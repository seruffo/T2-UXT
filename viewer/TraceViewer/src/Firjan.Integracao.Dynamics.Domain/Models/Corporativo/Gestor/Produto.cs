using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Models.SGE;
using System;
using System.Collections.Generic;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class Produto : TipoModel<int>
    {
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public DateTime? Validade { get; set; }
        public DateTime? Versao { get; set; }
        public int? ClassificacaoServicoId { get; set; }
        public ClassificacaoServico ClassificacaoServico { get; set; }
        public string FuncaoServicoTecnologicoCodigo { get; set; }
        public Funcao FuncaoServicoTecnologico { get; set; }
        public string CodigoServico { get; set; }
        public string CodigoServicoEspecialidade { get; set; }
        public Divulgado Divulgado { get; set; }
        public Divulgado DivulgadoSite { get; set; }
        public int? GrupoClassificacaoId { get; set; }
        public GrupoClassificacao GrupoClassificacao { get; set; }
        public int? GrupoClassificacaoPrimeiroNivelId { get; set; }
        public GrupoClassificacao GrupoClassificacaoPrimeiroNivel { get; set; }
        public Especialidade Especialidade { get; set; }
        public int? LinhaServicoId { get; set; }
        public LinhaServico LinhaServico { get; set; }
        public Byte? NivelServicoId { get; set; }
        public NivelServico NivelServico { get; set; }
        public string NomeResumido { get; set; }
        public int? PlataformaId { get; set; }
        public Plataforma Plataforma { get; set; }
        public Int16? TabelaServicoId { get; set; }
        public TabelaServico TabelaServico { get; set; }
        public int? TUSSId { get; set; }
        public TUSS TUSS { get; set; }
        public string TipoEntidadeVinculoId { get; set; }
        public TipoEntidadeVinculo TipoEntidadeVinculo { get; set; }
        public Dedutivel Dedutivel { get; set; }
        public char? TipoServicoId { get; set; }
        public TipoServico TipoServico { get; set; }
        public ValeCultura ValeCultura { get; set; }
        public string AreaId { get; set; }
        public STI.Area Area { get; set; }
        public string CodigoAreaDN { get; set; }
        public AreaDN AreaDN { get; set; }
        public bool? ExigeCPF { get; set; }
        public string NumeroAgente { get; set; }
        public int ServicoOficialId { get; set; }
        public Servico ServicoOficial { get; set; }
        public Lazer Lazer { get; set; }
        public Saude Saude { get; set; }
        public Flag CursoPadrao { get; set; }
        public Int16? ModalidadeId { get; set; }
        public ModalidadeCurso Modalidade { get; set; }
        public Tipos.TipoCliente TipoCliente { get; set; }
        public Flag Atendimento { get; set; }
        public Categoria Categoria { get; set; }
        public int? ProdutoEspecialidadeId { get; set; }
        public Produto ProdutoEspecialidade { get; set; }
        public ExigeContrato ExigeConfeccaoContrato { get; set; }
    }    
}
