using FirjanTests.Scenarios.Base.CRUD;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor.Odontograma
{
    public class SaudeFiguraOdontoTest : Base
    {
        public SaudeFiguraOdontoTest()
        {
            Body = new 
            {
                SaudeId = 482,
                FiguraOdontogramaId = 40
            };
            Configure("Gestor/Odontograma/SaudesFigurasOdontogramas", "482,5");
        }        
    }
}