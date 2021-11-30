using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma
{
    public class FiguraOdontograma : TipoModel<int>
    {
        public TipoFigura TipoFigura { get; set; }
        public byte[] Image { get; set; }
        public Local Local { get; set; }
        public decimal? Tamanho { get; set; }
        public Face Face1 { get; set; }
        public Face Face2 { get; set; }
        public Face Face3 { get; set; }
        public Face Face4 { get; set; }
        public Face Face5 { get; set; }
        public Raiz Raiz1 { get; set; }
        public Raiz Raiz2 { get; set; }
        public Raiz Raiz3 { get; set; }
        public Sentido Sentido { get; set; }
        public byte? Ordem { get; set; }
    }
}
