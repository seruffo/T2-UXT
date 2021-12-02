using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.STI
{
    ///<summary>
    ///Objeto Plataforma"/>
    ///</summary>
    [DataContract]
    public class PlataformaViewModel : TipoViewModel<int>
    {
        /// <summary>
        /// Código da área ocupacional
        /// Ex.: 38
        /// Atributo por indicar o código da área de segmento.
        /// </summary>
        [DataMember]
        public string CodigoArea { get; set; }
        /// <summary>
        /// Área ocupacional
        /// Atributo por indicar a área de segmento.
        /// </summary>
        [DataMember]
        public AreaViewModel Area { get; set; }
    }
}
