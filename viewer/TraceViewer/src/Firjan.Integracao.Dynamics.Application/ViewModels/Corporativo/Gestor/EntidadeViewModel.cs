using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto EntidadeViewModel"/>
    ///</summary>
    [DataContract]
    public class EntidadeViewModel : TipoViewModel<string>
    {
        [DataMember]
        public IEnumerable<GrupoClassificacao> GruposClassificacoes { get; set; } = null;
    }
}