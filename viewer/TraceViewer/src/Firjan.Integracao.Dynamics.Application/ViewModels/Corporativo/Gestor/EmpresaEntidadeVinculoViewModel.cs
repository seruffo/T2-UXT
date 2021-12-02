using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto Empresa EntidadeVinculo view"/>
    ///</summary>
    [DataContract]
    public class EmpresaEntidadeVinculoViewModel
    {
        [DataMember]
        public string CodigoTipoEntidadeVinculo { get; set; }
        [DataMember]
        public TipoEntidadeVinculoViewModel TipoEntidadeVinculo { get; set; }
        [DataMember]
        public string CodigoEmpresa { get; set; }
        [DataMember]
        public EmpresaViewModel Empresa { get; set; }
    }
}
