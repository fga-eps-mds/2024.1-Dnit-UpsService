using Moq;
using Service;
using Service.Interfaces;
using Repositorio.Interfaces;
using Entidades;

namespace test.SinistroServiceTests
{
    public class SinistroServiceTest
    {
        private readonly SinistroService sinistroService;
        private readonly Mock<ISinistroRepositorio> mockSinistroRepositorio;
        private string caminhoDoArquivo;
        private readonly string caminhoTests = Path.Join("..", "..", "..", "..", "test");

        public SinistroServiceTest()
        {
            caminhoDoArquivo = Path.Join(caminhoTests, "Stub", "ExemploSin.csv");
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
            mockSinistroRepositorio.Verify(mock => mock.Criar(It.IsAny<Sinistro>()), Times.Exactly(3));
        }

        [Fact]
        public void CadastrarSinistroViaPlanilha_QuandForChamado_DeveCadastrarSinistros()
        {
            var memoryStream = new MemoryStream(File.ReadAllBytes(caminhoDoArquivo));

            sinistroService.CadastrarSinistroViaPlanilha(memoryStream);
            mockSinistroRepositorio.Verify(mock => mock.Criar(It.IsAny<Sinistro>()), Times.Exactly(3));
        }

        [Fact]
        public void SuperaTamanhoMaximo_QuandoPlanilhaComTamanhoMaiorQueOMaximoForPassada_DeveRetornarTrue()
        {
            Mock<ISinistroRepositorio> mockSinistroRepositorio = new();
            ISinistroService sinistroService = new SinistroService(mockSinistroRepositorio.Object);

            caminhoDoArquivo = Path.Join(caminhoTests, "Stub", "planilhaExemploSinistro.csv");

            MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(caminhoDoArquivo));

            bool resultado = sinistroService.SuperaTamanhoMaximo(memoryStream);

            Assert.True(resultado);
        }
    }
}