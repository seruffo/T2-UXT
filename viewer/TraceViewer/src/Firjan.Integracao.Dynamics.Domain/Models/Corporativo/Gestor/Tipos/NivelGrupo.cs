using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    public class NivelGrupo : Enums<Byte?>
    {
        public static readonly NivelGrupo Primeiro = new NivelGrupo(1, "Primeiro");
        public static readonly NivelGrupo Segundo = new NivelGrupo(2, "Segundo");
        public static readonly NivelGrupo Terceiro = new NivelGrupo(3, "Terceiro");
        public static readonly NivelGrupo Quarto = new NivelGrupo(4, "Quarto");
        public static readonly NivelGrupo Quinto = new NivelGrupo(5, "Quinto");
        public static readonly NivelGrupo Sexto = new NivelGrupo(6, "Sexto");
        public static readonly NivelGrupo Setimo = new NivelGrupo(7, "Setimo");
        public static readonly NivelGrupo Oitavo = new NivelGrupo(8, "Oitavo");
        public NivelGrupo(Byte? key, string name) : base(key, name) { }
    }
}
