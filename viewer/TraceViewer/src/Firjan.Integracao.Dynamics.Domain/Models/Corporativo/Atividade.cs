using Firjan.Integracao.Dynamics.Domain.Models.Base;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo
{
    public class Atividade : TipoModel<string>
    {
        public Atividade(string id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
