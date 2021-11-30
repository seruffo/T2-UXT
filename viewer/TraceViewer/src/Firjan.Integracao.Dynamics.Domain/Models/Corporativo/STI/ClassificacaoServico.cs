using Firjan.Integracao.Dynamics.Domain.Models.Base;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI
{
    public class ClassificacaoServico : TipoModel<int>
    {
        public int LinhaServicoId { get; set; }
        public LinhaServico LinhaServico { get; set;}
        
        public string AreaDN { get; set; }
    }
}