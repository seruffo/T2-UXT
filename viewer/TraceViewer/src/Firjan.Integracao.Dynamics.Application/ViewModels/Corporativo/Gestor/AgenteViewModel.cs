using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto Area"/>
    ///</summary>
    [DataContract]
    public class AgenteViewModel : TipoViewModel<string>
    {
        [DataMember]
        public ProdutoViewModel Produto { get; set; }
        [DataMember]
        public string RiscoId { get; set; }
        [DataMember]
        public RiscoViewModel Risco { get; set; }
    }
}
