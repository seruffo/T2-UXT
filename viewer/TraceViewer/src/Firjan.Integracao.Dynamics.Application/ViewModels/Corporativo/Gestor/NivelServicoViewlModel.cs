using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    ///<summary>
    ///Objeto ServicoViewModel"/>
    ///</summary>
    [DataContract]
    public class NivelServicoViewlModel : TipoViewModel<int?>
    {
        [DataMember]
        public Int16? TabelaServicoId { get; set; }
        [DataMember]
        public TabelaServicoViewModel TabelaServico { get; set; }
    }
}
