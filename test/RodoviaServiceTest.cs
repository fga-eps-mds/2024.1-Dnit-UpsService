using Moq;
using service;
using repositorio.Interfaces;
using dominio;

namespace test.RodoviaServiceTests
{
    public class RodoviaServiceTest
    {
        private readonly RodoviaService rodoviaService;
        private readonly Mock<IRodoviaRepositorio> mockRodoviaRepositorio;
        private readonly string caminhoDoArquivo;
        public RodoviaServiceTest()
        {
            caminhoDoArquivo = "..\\..\\..\\..\\test\\Stub\\planilhaExemplo.csv";
            mockRodoviaRepositorio = new();
            rodoviaService = new RodoviaService(mockRodoviaRepositorio.Object);
        }
        [Fact]
        public void CadastrarRodoviaViaPlanilha_QuandoPlanilhaForPassadaENaoTiverDado_NaoDevePassarPeloRepositorio()
        {
            Assert.Throws<ArgumentNullException>(() => rodoviaService.CadastrarRodoviaViaPlanilha(null));
        }
        [Fact]
        public void CadastrarRodoviaViaPlanilha_QuandoForChamado_DeveChamarORepositorio()
        {;
            var memoryStream = new MemoryStream(File.ReadAllBytes(caminhoDoArquivo));

            rodoviaService.CadastrarRodoviaViaPlanilha(memoryStream);
            mockRodoviaRepositorio.Verify(mock => mock.CadastrarRodovia(It.IsAny<RodoviaDTO>()), Times.Exactly(3));
        }
        [Fact]
        public void CadastrarRodoviaViaPlanilha_QuandForChamado_DeveCadastrarRodovias()
        {
            var memoryStream = new MemoryStream(File.ReadAllBytes(caminhoDoArquivo));

            rodoviaService.CadastrarRodoviaViaPlanilha(memoryStream);
            mockRodoviaRepositorio.Verify(mock => mock.CadastrarRodovia(It.IsAny<RodoviaDTO>()), Times.Exactly(3));
        }

        [Fact]
        public void SuperaTamanhoMaximo_QuandoPlanilhaComTamanhoMaiorQueOMaximoForPassada_DeveRetornarTrue()
        {
            string caminhoArquivo = "..\\..\\..\\..\\test\\Stub\\planilha_tamanho_max.csv";

        MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(caminhoArquivo));

            bool resultado = rodoviaService.SuperaTamanhoMaximo(memoryStream);

            Assert.True(resultado);
        }
    }

}