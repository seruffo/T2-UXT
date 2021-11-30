using FluentValidation.Results;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class ClasseValorProduto
    {
        public ValidationResult ValidationResult { get; set; }
        public string CodigoEmpresa { get; set; }
        public string CodigoCentroResponsabilidade { get; set; }
        public int? ProdutoId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public int? GrupoClassifId { get; set; }
    }
}
