using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class Servico : TipoModel<int>
    {
        public Atendimento Atendimento { get; set; }
        public Int16? NaturezaServicoId { get; set; }
        public NaturezaServico NaturezaServico { get; set; }
        public string Objetivo { get; set; }
        public string Procedimento { get; set; }
        public Flag MarcaHora { get;set; }
        public string AreaId { get; set; }
        public Area Area { get; set; }
    }
}
