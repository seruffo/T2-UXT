using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    [DataContract]
    public class EnderecoUnidadeViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int? MunicipioId { get; set; }
        [DataMember]
        public MunicipioViewModel Municipio { get; set; }
        [DataMember]
        public Int16 UnidadeNegocioId { get; set; }
        [DataMember]
        public UnidadeNegocioViewModel UnidadeNegocio { get; set; }
        [DataMember]
        public string Logradouro { get; set; }
        [DataMember]
        public int? CodigoBairro { get; set; }
        [DataMember]
        public BairroViewModel Bairro { get; set; }
        [DataMember]
        public string Numero { get; set; }
        [DataMember]
        public string Complemento { get; set; }
        [DataMember]
        public string CEP { get; set; }
        [DataMember]
        public string PontoReferencia { get; set; }
        [DataMember]
        public TipoEndereco TipoEndereco { get; set; }
        [DataMember]
        public decimal? Latitude { get; set; }
        [DataMember]
        public decimal? Longitude { get; set; }
    }
}
