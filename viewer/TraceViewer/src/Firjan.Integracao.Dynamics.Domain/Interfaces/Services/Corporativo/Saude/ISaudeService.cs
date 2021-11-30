using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Saude
{
    public interface ISaudeService : IDisposable, IService<Models.Corporativo.Gestor.Saude>
    {
    }
}
