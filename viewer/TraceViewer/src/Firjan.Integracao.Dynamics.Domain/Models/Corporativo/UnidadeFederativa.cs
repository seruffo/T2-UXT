using Firjan.Integracao.Dynamics.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo
{
    public class UnidadeFederativa: TipoModel<string>
    {
        public UnidadeFederativa(string id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
