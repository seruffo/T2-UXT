using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using FluentValidation.Results;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto ClassificacaoViewModel"/>
    ///</summary>
    [DataContract]
    public class ClassificacaoViewModel
    {
        public ValidationResult ValidationResult { get; set; }
        public int GrupoProdutoId { get; set; }
        public GrupoClassificacaoViewModel GrupoClassificacao { get; set; }
        public int? ProdutoId { get; set; }
        public ProdutoViewModel Produto { get; set; }
        public char FlagDivulgado { get; set; }
        public Divulgado Divulgado { get; set; }
        public bool? NovaInterface { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}
