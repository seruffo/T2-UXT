using FluentValidation.Results;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class ContaContabilProduto
    {
        public ValidationResult ValidationResult { get; set; }
        private string codigoEmpresa_;
        public string CodigoEmpresa { get => codigoEmpresa_.Trim(); set => codigoEmpresa_ = value; }
        private string codigoConta_;
        public string CodigoConta { get => codigoConta_.Trim(); set => codigoConta_ = value; }
        public int? ProdutoId { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public char? IsAssistencial { get; set; }
        public int? GrupoClassifId { get; set; }
    }
}
