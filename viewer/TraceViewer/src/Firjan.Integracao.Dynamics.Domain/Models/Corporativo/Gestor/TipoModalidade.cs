using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class TipoModalidade : TipoModel<Int16?>
    {
        public string Codigo { get; set; }
        public string CodigoDN { get; set; }
        public Int16 ModalidadeId { get; set; }
        public Modalidade Modalidade { get; set; }
        public char? AcaoId { get; set; }
        public Acao Acao => Enumeration.FromKey<Acao>(AcaoId);
        
    }
}
