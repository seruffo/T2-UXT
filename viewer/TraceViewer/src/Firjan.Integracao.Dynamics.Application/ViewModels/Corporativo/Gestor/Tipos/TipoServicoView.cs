using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos
{
    public class TipoServicoView : Enumeration
    {
        public static TipoServicoView MeioAmbiente = new TipoServicoView('B', "Meio Ambiente");
        public static TipoServicoView AssistenciaSocial = new TipoServicoView('C', "Assistência Social");
        public static TipoServicoView Educacao = new TipoServicoView('E', "Educação");
        public static TipoServicoView Lazer = new TipoServicoView('L', "Lazer");
        public static TipoServicoView Administracao = new TipoServicoView('M', "Administração");
        public static TipoServicoView Alimentacao = new TipoServicoView('N', "Alimentação");
        public static TipoServicoView Saude = new TipoServicoView('S', "Saúde");
        public static TipoServicoView Tecnologico = new TipoServicoView('T', "Servico Tecnológico");
        public static TipoServicoView Cultura = new TipoServicoView('U', "Cultura");
        public TipoServicoView(char? key, string displayName) : base(key, displayName) { }
    }
}
