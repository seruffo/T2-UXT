
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Odontograma
{
    ///<summary>
    ///Objeto OdontogramaViewModel"/>
    ///</summary>
    [DataContract]
    public class OdontogramaViewModel : Base.Base
    {
        [DataMember]
        public Byte NumeroDente { get; set; }
        [DataMember]
        public Operacao Operacao { get; set; }
        [DataMember]
        public string AtendimentoId { get; set; }
        [DataMember]
        public Domain.Models.Corporativo.Gestor.Odontograma.Atendimento Atendimento { get; set; }
        [DataMember]
        public Radiografia Radiografia { get; set; }
        [DataMember]
        public Raiz Raiz1 { get; set; }
        [DataMember]
        public Raiz Raiz2 { get; set; }
        [DataMember]
        public Raiz Raiz3 { get; set; }
        [DataMember]
        public Face Face1 { get; set; }
        [DataMember]
        public Face Face2 { get; set; }
        [DataMember]
        public Face Face3 { get; set; }
        [DataMember]
        public Face Face4 { get; set; }
        [DataMember]
        public Face Face5 { get; set; }
        [DataMember]
        public int PessoaId { get; set; }
        [DataMember]
        public Pessoa Pessoa { get; set; }
        [DataMember]
        public DateTime? DataRadiografia { get; set; }
        [DataMember]
        public int FiguraOdontogramaId { get; set; }
        [DataMember]
        public FiguraOdontograma FiguraOdontograma { get; set; }        
    }
}
