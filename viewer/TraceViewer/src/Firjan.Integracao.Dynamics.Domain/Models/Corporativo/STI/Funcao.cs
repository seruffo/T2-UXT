using Firjan.Integracao.Dynamics.Domain.Models.Base;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI
{
    public class Funcao : TipoModel<string>
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Sigla { get; set; }
        public bool ParticipantePF { get; set; }
        public bool ParticipantePJ { get; set; }
        public bool ValidaFavorecidoContratoPF { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }
    }
}