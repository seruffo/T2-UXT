using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class TipoMatriz : Enums<string>
    {
        public static TipoMatriz CIRJ = new TipoMatriz("01", "CIRJ");
        public static TipoMatriz MovimentoSindical = new TipoMatriz("02", "Movimento Sindical");
        public static TipoMatriz ADM026 = new TipoMatriz("03", "ADM026-Convênio Concessão de Descontos a Empresas Não Regimentais");
        public static TipoMatriz ADM027 = new TipoMatriz("04", "ADM027-Convênio Concessão de Descontos a Associação de Empresas");
        public static TipoMatriz ADM031 = new TipoMatriz("05", "ADM031-Convênio Concessão de Descontos a Empresas Associadas");
        public static TipoMatriz ADM028 = new TipoMatriz("06", "ADM028-Convênio Concessão de Valor Regimental a Empresa Não Regimental");
        public static TipoMatriz MetalSul = new TipoMatriz("08", "MetalSul");
        public static TipoMatriz AIPERJ = new TipoMatriz("09", "AIPERJ");
        public static TipoMatriz FIRJAN = new TipoMatriz("10", "FILIAÇÃO FIRJAN");
        public static TipoMatriz ADM091 = new TipoMatriz("11", "ADM091-Conv Concessão Descontos Empresas Movimento Sindical");
        public static TipoMatriz ADM092 = new TipoMatriz("12", "ADM092-Conv.Concessão Descontos Empresas Movimento Sindical com SESMT Próprio");
        public static TipoMatriz ADM098 = new TipoMatriz("13", "ADM098-Concessão Descontos Entidades sem fins lucrativo e não empresarial");

        public TipoMatriz(string key, string displayName) : base(key, displayName) { }
    }
}
