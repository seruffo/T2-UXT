using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoServico : Enums<char?>
    {
        public static TipoServico EducacaoExecutiva = new TipoServico('A', "EDUCAÇÃO EXECUTIVA");
        public static TipoServico MeioAmbiente = new TipoServico('B', "Meio Ambiente");
        public static TipoServico AssistenciaSocial = new TipoServico('C', "Assistência Social");
        public static TipoServico ServicosIEL = new TipoServico('D', "Serviços Intitucionais IEL");
        public static TipoServico Educacao = new TipoServico('E', "Educação");
        public static TipoServico AtendimentoSetorial = new TipoServico('F', "Atendimento Setorial");
        public static TipoServico ProgramaEstagio = new TipoServico('G', "Programa de Estágio");
        public static TipoServico SegurancaTrabalho = new TipoServico('H', "Segurança do Trabalho");
        public static TipoServico Diversos = new TipoServico('I', "Diversos - Reneg");
        public static TipoServico CIRJ = new TipoServico('J', "Serviços Intitucionais CIRJ");
        public static TipoServico FIRJAN = new TipoServico('K', "Casa Firjan");
        public static TipoServico EsporteLazer = new TipoServico('L', "Esporte e Lazer");
        public static TipoServico Administracao = new TipoServico('M', "Administração");
        public static TipoServico Alimentacao = new TipoServico('N', "Alimentação");
        public static TipoServico GestaoEmpresarial = new TipoServico('O', "Gestão Empresarial");
        public static TipoServico ResponsabilidadeSocial = new TipoServico('R', "Responsabilidade Social Corporativa");
        public static TipoServico Saude = new TipoServico('S', "Saúde");
        public static TipoServico Tecnologico = new TipoServico('T', "Servico Tecnológico");
        public static TipoServico Cultura = new TipoServico('U', "Cultura");
        public static TipoServico DemandasEmpresariais = new TipoServico('V', "Demandas Empresariais");
        public static TipoServico Convenio = new TipoServico('W', "Convênio");
        public static TipoServico ComercioExterior = new TipoServico('X', "Comércio Exterior");
        public TipoServico(char? key, string displayName) : base(key, displayName) { }
    }
}
