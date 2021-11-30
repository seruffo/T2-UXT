using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto Empresa"/>
    ///</summary>
    [DataContract]
    public class EmpresaViewModel : TipoViewModel<string>
    {
        [DataMember]
        public List<GrupoClassificacaoViewModel> GruposClassificacoes { get; set; }
    }
}