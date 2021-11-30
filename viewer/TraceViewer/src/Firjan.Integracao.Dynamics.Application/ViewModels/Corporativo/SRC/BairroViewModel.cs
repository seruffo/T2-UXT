using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC
{
    ///<summary>
    ///Objeto Bairro"/>
    ///</summary>
    public class BairroViewModel : TipoViewModel<int>
    {
        ///<summary>
        ///Código do Município
        ///</summary>
        [DataMember]
        public int CodigoMunicipio { get; set; }
        ///<summary>
        ///Município
        ///</summary>
        [DataMember]
        public MunicipioViewModel Municipio { get; set; }
        ///<summary>
        ///Código do local do Bairro da tabela correio
        ///</summary>
        [DataMember]
        public string CodigoLocalCorreio { get; set; }
        ///<summary>
        ///Código do Bairro da tabela correio
        ///</summary>
        [DataMember]
        public string CodigoBairroCorreio { get; set; }
        ///<summary>
        ///Status do Bairro, se o Bairro encontra-se ativo("S") ou não("N") para o cadastramento de novos endereços 
        ///</summary>
        [DataMember]
        public char? Ativo { get; set; }
        ///<summary>
        ///Descrição abreviada do Bairro
        ///</summary>
        [DataMember]
        public string DescricaoAbreviada { get; set; }
    }
}