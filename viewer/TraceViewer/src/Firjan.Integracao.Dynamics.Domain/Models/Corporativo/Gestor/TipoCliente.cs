
using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class TipoCliente : TipoModel<string>
    {
        public TipoPessoa Qualificador { get; set; }
        public EmpresaSistema EmpresaSistema { get; set; }
    }
}
