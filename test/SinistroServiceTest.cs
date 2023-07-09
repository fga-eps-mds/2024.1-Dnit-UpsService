using Moq;
using service;
using repositorio;
using service.Interfaces;
using repositorio.Interfaces;
using dominio;
using test.Stub;

namespace test.SinistroServiceTests
{
    public class SinistroServiceTest
    {
        private readonly SinistroService rodoviaService;
        private readonly Mock<ISinistroRepositorio> mockRodoviaRepositorio;
        private readonly string caminhoDoArquivo;
        public SinistroServiceTest()
        {
            caminhoDoArquivo = "..\\..\\..\\..\\test\\Stub\\planilhaExemplo.csv";
            mockRodoviaRepositorio = new();
            rodoviaService = new SinistroService(mockRodoviaRepositorio.Object);
        }
        [Fact]
        public void CadastrarRodoviaViaPlanilha_QuandoPlanilhaForPassadaENaoTiverDado_NaoDevePassarPeloRepositorio()
        {
            Assert.Throws<ArgumentNullException>(() => rodoviaService.CadastrarSinistroViaPlanilha(null));
        }
        [Fact]
        public void CadastrarRodoviaViaPlanilha_QuandoForChamado_DeveChamarORepositorio()
        {
            ;
            var memoryStream = new MemoryStream(File.ReadAllBytes(caminhoDoArquivo));

            rodoviaService.CadastrarSinistroViaPlanilha(memoryStream);
            mockRodoviaRepositorio.Verify(mock => mock.CadastrarSinistro(It.IsAny<Sinistro>()), Times.Exactly(3));
        }
        [Fact]
        public void CadastrarRodoviaViaPlanilha_QuandForChamado_DeveCadastrarRodovias()
        {
            var memoryStream = new MemoryStream(File.ReadAllBytes(caminhoDoArquivo));

            rodoviaService.CadastrarSinistroViaPlanilha(memoryStream);
            mockRodoviaRepositorio.Verify(mock => mock.CadastrarSinistro(It.IsAny<Sinistro>()), Times.Exactly(3));
        }

        [Fact]
        public void SuperaTamanhoMaximo_QuandoPlanilhaComTamanhoMaiorQueOMaximoForPassada_DeveRetornarTrue()
        {
            Mock<ISinistroRepositorio> mockSinistroRepositorio = new();
            ISinistroService sinistroService = new SinistroService(mockSinistroRepositorio.Object);

            string caminhoArquivo = "..\\..\\..\\..\\test\\Stub\\planilhaExemploSinistro.csv";

            MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(caminhoArquivo));

            bool resultado = sinistroService.SuperaTamanhoMaximo(memoryStream);

            Assert.True(resultado);
        }
    }
}