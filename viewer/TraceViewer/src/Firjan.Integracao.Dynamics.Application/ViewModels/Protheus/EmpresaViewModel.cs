using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Protheus
{
    ///<summary>
    ///Objeto Empresa"/>
    ///</summary>
    [DataContract]
    public class EmpresaViewModel : TipoViewModel<string>
    {
        [DataMember]
        public string Nome { get; set; }
    }
}