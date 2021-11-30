using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class EmpresaSistema : Enums<char?>
    {
        public static readonly EmpresaSistema SESI = new EmpresaSistema('1',"SESI");
        public static readonly EmpresaSistema SENAI = new EmpresaSistema('2', "SENAI");
        public static readonly EmpresaSistema FIRJAN = new EmpresaSistema('3', "FIRJAN");
        public static readonly EmpresaSistema CIRJ = new EmpresaSistema('4', "CIRJ");
        public EmpresaSistema(char? key, string name) : base(key, name) { }
    }
}
