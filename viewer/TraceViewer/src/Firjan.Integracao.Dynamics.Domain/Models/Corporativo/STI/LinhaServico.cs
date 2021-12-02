using Firjan.Integracao.Dynamics.Domain.Models.Base;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI
{
    public class LinhaServico: TipoModel<int>
    {
        public string CodigoFuncao { get; set; }
        public Funcao Funcao { get; set; }
    }
}