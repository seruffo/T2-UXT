using FirjanTests.Scenarios.Base.CRUD;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor
{
    public class ProdutoTipoFichaTest : Base
    {
        public ProdutoTipoFichaTest()
        {
            Body = new
            {
                ProdutoId = 46,
                TipoFichaId = 33,
                GeraAtendimento = new 
                { 
                    Id = 'N', 
                    Name = "Não" 
                },
                ServicoId = 36
            };

            Configure("Gestor/Saude/ProdutosTiposFichas", "46,36,17");
        }
    }
}