using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using System;
using System.Collections.Generic;

namespace Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor
{
    public interface IEmpresaEntidadeVinculoService : IDisposable, IService<EmpresaEntidadeVinculo>
    {
        IEnumerator<string> GetTiposEntidadesVinculosIds(string empresaId);
    }
}
