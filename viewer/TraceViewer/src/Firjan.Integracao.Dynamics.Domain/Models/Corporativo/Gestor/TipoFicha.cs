using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class TipoFicha : TipoModel<int>
    {
        public Flag HistFisioVac { get; set; } 
        public Flag HistFam { get; set; } 
        public Flag HppInter { get; set; } 
        public Flag HppDoencas { get; set; } 
        public Flag Habitos { get; set; } 
        public Flag CondHab { get; set; } 
        public Flag Torax { get; set; } 
        public Flag Membros { get; set; } 
        public Flag Coluna { get; set; } 
        public Flag ExameGer { get; set; } 
        public Flag Abdome { get; set; } 
        public Flag Imunizacao { get; set; } 
        public Flag BioComport { get; set; } 
        public Flag CabecaPescoco { get; set; } 
        public Flag CondTrab { get; set; } 
        public Flag AcidTrab { get; set; } 
        public Flag Faixa { get; set; } 
        public Flag ColabResp { get; set; } 
        public Flag ColabAtend { get; set; } 
        public Flag QtdEspectad { get; set; } 
        public Flag IndiSerie { get; set; } 
        public Flag Assistencial { get; set; } 
        public Flag TotAtend { get; set; } 
        public Flag Evento { get; set; } 
        public Flag Tema { get; set; } 
        public Flag QtdAtend { get; set; } 
        public Flag Entidade { get; set; } 
        public Flag Pessoa { get; set; } 
        public TipoUtilizacao TipoUtilizacao { get; set; }
        public Flag Umo { get; set; } 
        public Flag PrimVez { get; set; } 
        public Flag PrimeSpec { get; set; } 
        public Flag Dente { get; set; } 
        public Flag Valor { get; set; } 
        public Flag QtPesAtend { get; set; } 
        public Flag Turma { get; set; } 
        public Flag EntPrestadora { get; set; } 
        public TipoPreenchimento TipoPreenchimento { get; set; } 
        public Flag PublAlvo { get; set; } 
        public Flag Despesa { get; set; } 
        public Flag Receita { get; set; } 
        public Flag CidDeficiencia { get; set; } 
        public Flag GeraAtendimento { get; set; } 
    }
}