using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using FluentValidation.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class EnderecoUnidade
    {
        public int Id { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public int? MunicipioId { get; set; }
        public Municipio Municipio { get; set; }
        public Int16 UnidadeNegocioId { get; set; }
        public UnidadeNegocio UnidadeNegocio { get; set; }
        public string Logradouro { get; set; }
        public int? BairroId { get; set; }
        public Bairro Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string PontoReferencia { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public TipoEndereco TipoEndereco { get; set; }
    }
}
