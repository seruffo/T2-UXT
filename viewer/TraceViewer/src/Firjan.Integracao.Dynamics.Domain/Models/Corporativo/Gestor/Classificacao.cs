using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using FluentValidation.Results;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class Classificacao
    {
        public ValidationResult ValidationResult { get; set; }
        public int GrupoClassificacaoId { get; set; }
        public GrupoClassificacao GrupoClassificacao { get; set; }
        public int? ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public Divulgado Divulgado { get; set; }
        public bool? NovaInterface { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}
