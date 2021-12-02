using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class TipoOrigemServicoView : Enums<char?>
    {
        [DataMember]
        public static TipoOrigemServicoView MeioAmbiente = new TipoOrigemServicoView('1', "Admissional");
        [DataMember]
        public static TipoOrigemServicoView AssistenciaSocial = new TipoOrigemServicoView('2', "Periódico");
        [DataMember]
        public static TipoOrigemServicoView Educacao = new TipoOrigemServicoView('3', "Retorno ao trabalho");
        [DataMember]
        public static TipoOrigemServicoView MudancaFuncao = new TipoOrigemServicoView('4', "Mudança de Função");
        [DataMember]
        public static TipoOrigemServicoView Demissional = new TipoOrigemServicoView('5', "Demissional");
        public TipoOrigemServicoView(char? key, string displayName) : base(key, displayName) { }
    }
}
