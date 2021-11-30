using Firjan.Integracao.Dynamics.Domain.Models.Base;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor
{
    public class Municipio : TipoModel<int>
    {
        public int? Codigo { get; set; }
        public string SiglaUF { get; set; }
        public UF UF { get; set; }
        public string CEP { get; set; }
        //public EnumTipoMunicipio TipoMunicipio { get; set; }
        //public enum EnumTipoMunicipio
        //{
        //    Municipio = 'M',
        //    Povoado = 'P',
        //    Distrito = 'D'
        //}
        //public EnumAtivoMunicipio Ativo { get; set; }
        //public enum EnumAtivoMunicipio
        //{
        //    Sim = 'S',
        //    Nao = 'N'
        //}
    }
}