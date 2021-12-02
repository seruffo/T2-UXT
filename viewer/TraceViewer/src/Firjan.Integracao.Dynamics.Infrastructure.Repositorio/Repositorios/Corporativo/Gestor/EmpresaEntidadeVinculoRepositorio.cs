using System.Collections.Generic;
using System.Linq;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor
{
    public class EmpresaEntidadeVinculoRepositorio : CorporativoRepositorio<EmpresaEntidadeVinculo>, IEmpresaEntidadeVinculoRepository
    {
        public EmpresaEntidadeVinculoRepositorio(CorporativoContext context) : base(context) { }

        public IEnumerator<string> GetTiposEntidadesVinculosIds(string empresaId)
        {
            var result = _contexto.EmpresasEntidadesVinculos.Where(s => s.EmpresaId == empresaId).Select(s => s.TipoEntidadeVinculoId).GetEnumerator();
            return  result as IEnumerator<string>;          
        }
    }    
}