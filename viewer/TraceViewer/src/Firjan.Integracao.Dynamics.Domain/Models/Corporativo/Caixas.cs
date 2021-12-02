using Firjan.Integracao.Dynamics.Domain.Models.Base;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo
{
    public class Caixas : TipoModel<string>
    {
        public Caixas(string id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
