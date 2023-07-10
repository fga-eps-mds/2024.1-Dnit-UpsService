using Moq;
using service;
using repositorio;
using service.Interfaces;
using repositorio.Interfaces;
using dominio;

using System.IO;


namespace test.SinistroServiceTests
{
    public class SinistroServiceTest
    {
        private readonly SinistroService sinistroService;
        private readonly Mock<ISinistroRepositorio> mockSinistroRepositorio;
        private readonly string caminhoDoArquivo;
        public SinistroServiceTest()
        {
            caminhoDoArquivo = "..\\..\\..\\..\\test\\Stub\\ExemploSin.csv";
            mockSinistroRepositorio = new();
            sinistroService = new SinistroService(mockSinistroRepositorio.Object);
        }
        [Fact]
        public void CadastrarSinistroViaPlanilha_QuandoPlanilhaForPassadaENaoTiverDado_NaoDevePassarPeloRepositorio()
        {
            Assert.Throws<ArgumentNullException>(() => sinistroService.CadastrarSinistroViaPlanilha(null));
        }
        [Fact]
        public void CadastrarSinistroViaPlanilha_QuandoForChamado_DeveChamarORepositorio()
        {
            var memoryStream = new MemoryStream(File.ReadAllBytes(caminhoDoArquivo));

            sinistroService.CadastrarSinistroViaPlanilha(memoryStream);
            mockSinistroRepositorio.Verify(mock => mock.CadastrarSinistro(It.IsAny<Sinistro>()), Times.Exactly(3));
        }
        [Fact]
        public void CadastrarSinistroViaPlanilha_QuandForChamado_DeveCadastrarSinistros()
        {
            var memoryStream = new MemoryStream(File.ReadAllBytes(caminhoDoArquivo));

            sinistroService.CadastrarSinistroViaPlanilha(memoryStream);
            mockSinistroRepositorio.Verify(mock => mock.CadastrarSinistro(It.IsAny<Sinistro>()), Times.Exactly(3));
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