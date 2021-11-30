using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.SMAIS
{
    public class ExameViewModel : TipoViewModel<int?>
    {
        ///<summary>
        ///Ativo
        ///</summary>
        [DataMember]
        public string Codigo { get; set; }
        ///<summary>
        ///Ativo
        ///</summary>
        [DataMember]
        public string Ativo { get; set; }
    }
}
