using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC
{
    ///<summary>
    ///Objeto Entidade"/>
    ///</summary>
    [DataContract]
    public class EntidadeViewModel : TipoViewModel<int>
    {
        [DataMember]
        public string TipoEntidadeVinculoId { get; set; }

        [DataMember]
        public TipoEntidadeVinculoViewModel TipoEntidadeVinculo { get; set; }
    }
}