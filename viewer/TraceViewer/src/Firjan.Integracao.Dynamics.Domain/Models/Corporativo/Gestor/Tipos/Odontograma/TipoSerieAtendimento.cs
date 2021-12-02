using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma
{
    public class TipoSerieAtendimento : Enums<char?>
    {
        public static readonly TipoSerieAtendimento InicioTratamento = new TipoSerieAtendimento('I', "Início Tratamento");
        public static readonly TipoSerieAtendimento ContinuacaoTratamento = new TipoSerieAtendimento('C', "Em Tratamento/Continuação");
        public static readonly TipoSerieAtendimento Termino = new TipoSerieAtendimento('T', "Termino/Alta no Tratamento");
        public static readonly TipoSerieAtendimento Ambas = new TipoSerieAtendimento('F', "Fora da série");
        public TipoSerieAtendimento(char? key, string name) : base(key, name) { }
    }
}
