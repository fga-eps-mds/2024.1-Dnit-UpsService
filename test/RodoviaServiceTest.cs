using Moq;
using service;
using repositorio;
using service.Interfaces;
using repositorio.Interfaces;
using dominio;
using test.Stub;

namespace test.RodoviaServiceTests
{
    public class RodoviaServiceTest
    {
        private readonly RodoviaService rodoviaService;
        private readonly Mock<IRodoviaRepositorio> mockRodoviaRepositorio;
        public RodoviaServiceTest()
        {
            mockRodoviaRepositorio = new();
            rodoviaService = new RodoviaService(mockRodoviaRepositorio.Object);
        }
        [Fact]
        public void CadastrarRodoviaViaPlanilha_QuandoPlanilhaForPassadaENaoTiverDado_NaoDevePassarPeloRepositorio()
        {
            var memoryStream = new MemoryStream();

            rodoviaService.CadastrarRodoviaViaPlanilha(memoryStream);
            mockRodoviaRepositorio.Verify(mock => mock.CadastrarRodovia(It.IsAny<RodoviaDTO>()), Times.Never);
        }
        [Fact]
        public void CadastrarRodoviaViaPlanilha_QuandoForChamado_DeveChamarORepositorioUmaVez()
        {
            var memoryStream = new MemoryStream();
        
        }
        [Fact]
        public void CadastrarRodoviaViaPlanilha_QuandoCadastroFalhar_DeveChamarORepositorioUmaVez()
        {
            var memoryStream = new MemoryStream();
            
        }

    }

}