using app.Controllers;
using Moq;
using service.Interfaces;
using test.Stub;

namespace test
{
    public class RodoviaControllerTest
    {
        private readonly Mock<IRodoviaService> rodoviaServiceMock;
        private readonly RodoviaController rodoviaController;
        
        public RodoviaControllerTest()
        {
            rodoviaServiceMock = new Mock<IRodoviaService>();
            rodoviaController = new RodoviaController(rodoviaServiceMock.Object);
        }

        [Fact]
        public void EnviarPlanilha_QuandoPlanilhaForEnviada_DeveRetornarHttpOk()
        {
            string caminhoArquivo = "../../Stub/"
            var stream = new MemoryStream();

            var resultado = rodoviaController.EnviarPlanilha(stream);

            Assert.Equal
        }
    }
}
