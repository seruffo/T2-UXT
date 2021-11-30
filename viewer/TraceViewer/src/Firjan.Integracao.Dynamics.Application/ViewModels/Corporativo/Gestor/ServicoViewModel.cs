using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;
using System;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    public class ServicoViewModel : TipoViewModel<int>
    {
        public Atendimento Atendimento { get; set; }
        public Int16? NaturezaServicoId { get; set; }
        public NaturezaServicoViewModel NaturezaServico { get; set; }
        public string Objetivo { get; set; }
        public string Procedimento { get; set; }
        public Flag MarcaHora { get;set; }
        public string AreaId { get; set; }
        public AreaViewModel Area { get; set; }
    }
}
