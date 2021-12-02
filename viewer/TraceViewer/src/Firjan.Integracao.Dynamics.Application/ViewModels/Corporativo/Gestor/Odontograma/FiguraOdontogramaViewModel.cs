using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Odontograma
{
    [DataContract]
    public class FiguraOdontogramaViewModel : TipoViewModel<int>
    {
        [DataMember]
        public TipoFigura TipoFigura { get; set; }
        [DataMember]
        public byte[] Image { get; set; }
        [DataMember]
        public Local Local { get; set; }
        [DataMember]
        public decimal? Tamanho { get; set; }
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
        public Raiz Raiz1 { get; set; }
        [DataMember]
        public Raiz Raiz2 { get; set; }
        [DataMember]
        public Raiz Raiz3 { get; set; }
        [DataMember]
        public Sentido Sentido { get; set; }
        [DataMember]
        public byte? Ordem { get; set; } = null;
    }
}
