using Firjan.Integracao.Dynamics.Domain.Models.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using System.Collections.Generic;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus
{
    public class Empresa : TipoModel<string>
    {
        public string Nome { get; set; }

        public IEnumerable<EmpresaEntidadeVinculo> EmpresasEntidadesVinculos { get; set; }
    }
}