
using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class Colaborador : TipoModel<int>
    {
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public Qualificador Qualificador { get; set; }
        public DateTime Cancelamento { get; set; }
    }
}
