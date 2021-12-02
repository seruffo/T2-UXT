using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma
{
    public class Odontograma : Base.Base
    {
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public Byte NumeroDente { get; set; }
        public int FiguraOdontogramaId { get; set; }
        public FiguraOdontograma FiguraOdontograma { get; set; }
        public string AtendimentoId { get; set; }
        public Atendimento Atendimento { get; set; }
        public Operacao Operacao { get; set; }
        public Radiografia Radiografia { get; set; }
        public Raiz Raiz1 { get; set; }
        public Raiz Raiz2 { get; set; }
        public Raiz Raiz3 { get; set; }
        public Face Face1 { get; set; }
        public Face Face2 { get; set; }
        public Face Face3 { get; set; }
        public Face Face4 { get; set; }
        public Face Face5 { get; set; }
        public DateTime? DataRadiografia { get; set; }
    }
}
