using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos
{
    [DataContract]
    public class CategoriaProdutoView : Enumeration
    {
        [DataMember]
        public static CategoriaProdutoView Material = new CategoriaProdutoView('M', "Material");
        [DataMember]
        public static CategoriaProdutoView Pacote = new CategoriaProdutoView('P', "Pacote");
        [DataMember]
        public static CategoriaProdutoView Grupo = new CategoriaProdutoView('G', "Grupo");
        [DataMember]
        public static CategoriaProdutoView Servicos = new CategoriaProdutoView('S', "Servicos");

        public CategoriaProdutoView(char? key, string displayName) : base(key, displayName) { }
    }
}
