using System;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class ModuloVersao : Base.Base
    {
        public string Codigo { get; set; } = null;
        public string NumeroVersao { get; set; } = null;
        public Int16? QtdHoras { get; set; }
        public DateTime? Fim { get; set; }
        public int? ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public Int16? QtddDias { get; set; }
        public Int16? TipoModalidadeId { get; set; }
        public TipoModalidade TipoModalidade { get; set; }
        public char CodigoInstrucao { get; set; }
        public Instrucao Instrucao { get; set; }
        public Int16? QtdHorasEstagio { get; set; }
        public TipoModulo TipoModulo { get; set; }
        public GeraNumeroCertificado GeraNumeroCertificado { get; set; }
        public ContemDisciplina ContemDisciplina { get; set; }
        public RefazCurso RefazCurso { get; set; }
        public int? PortifolioEducacaoId { get; set; }
        public PortifolioEducacao PortifolioEducacao { get; set; }
        public bool FlagProcessoSeletivo { get; set; }
        public CustoSistema CustoSistema { get; set; }
        public byte IdadeMinimaEducacao { get; set; }
        public byte IdadeMaximaEducacao { get; set; }
        public string Nome { get; set; }
        public string NomeResumido { get; set; }
        public DateTime Inicio { get; set; }
        public string Missao { get; set; }
    }
}
