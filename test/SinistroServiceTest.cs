using Moq;
using Service;
using Repositorio.Interfaces;
using Entidades;
using app.Entidades;
using Microsoft.EntityFrameworkCore;

namespace test.SinistroServiceTests
{
    public class SinistroServiceTest
    {
        private readonly DbContextOptions<AppDbContext> options = new();
        private readonly Mock<AppDbContext> mockDb;
        private readonly SinistroService sinistroService;
        private readonly Mock<ISinistroRepositorio> mockSinistroRepositorio;
        private readonly string caminhoTests = Path.Join("..", "..", "..", "..", "test");
        private string caminhoDoArquivo;

        public SinistroServiceTest()
        {
            mockSinistroRepositorio = new();
            mockDb = new(options);
            sinistroService = new SinistroService(mockSinistroRepositorio.Object, mockDb.Object);
            caminhoDoArquivo = Path.Join(caminhoTests, "Stub", "ExemploSin.csv");
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
            caminhoDoArquivo = Path.Join(caminhoTests, "Stub", "planilhaExemploSinistro.csv");

            var memoryStream = new MemoryStream(File.ReadAllBytes(caminhoDoArquivo));
            bool resultado = sinistroService.SuperaTamanhoMaximo(memoryStream);
            Assert.True(resultado);
        }
    }
}