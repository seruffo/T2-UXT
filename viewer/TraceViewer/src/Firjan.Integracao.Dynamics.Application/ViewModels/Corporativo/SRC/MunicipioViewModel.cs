using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC
{
    public class MunicipioViewModel : TipoViewModel<int>
    {
        ///<summary>
        ///Código do município.
        ///</summary>
        [DataMember]
        public int? Codigo { get; set; }
        ///<summary>
        ///Sigla da UF.
        ///</summary>
        [DataMember]
        public string SiglaUF { get; set; }
        ///<summary>
        ///UF.
        ///</summary>
        [DataMember]
        public UFViewModel UFViewModel { get; set; }
        ///<summary>
        ///CEP.
        ///</summary>
        [DataMember]
        public string CEP { get; set; }
        /// <summary>
        /// Tipo de município
        /// D= Distrito
        /// M = Município
        /// P = Povoado
        /// </summary>
        //[JsonProperty("TipoMunicipio")]
        //public EnumTipoMunicipioViewModel TipoMunicipio { get; set; }
        //public enum EnumTipoMunicipioViewModel
        //{
        //    Municipio = 'M',
        //    Povoado = 'P',
        //    Distrito = 'D'
        //}
        /// <summary>
        /// Status do Municipio, se o Municipio encontrasse ativo ("S') ou não ("N') para o cadastramento de novos enderecos.
        /// S = Municípios aptos ao cadastramento;
        /// N = Municípios inconsistentes com a base dos Correios
        /// </summary>
        //[DataMember]
        //public EnumAtivoMunicipioViewModel Ativo { get; set; }
        //public enum EnumAtivoMunicipioViewModel
        //{
        //    Sim = 'S',
        //    Povoado = 'N'
        //}
    }
}