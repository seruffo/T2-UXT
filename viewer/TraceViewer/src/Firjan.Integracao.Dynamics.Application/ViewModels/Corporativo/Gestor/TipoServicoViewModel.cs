using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    [DataContract]
    public class TipoServicoViewModel : TipoViewModel<char?>
    {
        [DataMember]
        public string Sigla { get; set; }
        [DataMember]
        public ObrigaArea ObrigaArea { get; set; }
        [DataMember]
        public ObrigaCusto ObrigaCusto { get; set; }
    }
}
