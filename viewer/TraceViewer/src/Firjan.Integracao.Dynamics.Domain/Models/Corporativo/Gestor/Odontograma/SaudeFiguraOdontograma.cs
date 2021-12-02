using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma
{
    public class SaudeFiguraOdontograma : Base.BaseClass
    {
        public int SaudeId { get; set; }
        public Saude Saude { get; set; }
        public int? FiguraOdontogramaId { get; set; }
        public FiguraOdontograma FiguraOdontograma { get; set; }
        public Obrigatorio Obrigatorio { get; set; } = Obrigatorio.Nao;
    }
}
