using Moq;
using Service;
using Repositorio.Interfaces;
using Entidades;
using app.Entidades;
using Microsoft.EntityFrameworkCore;

namespace test.RodoviaServiceTests
{
    public class RodoviaServiceTest
    {
        private readonly RodoviaService rodoviaService;
        private readonly Mock<IRodoviaRepositorio> mockRodoviaRepositorio;
        private readonly Mock<AppDbContext> mockDb;
        private readonly DbContextOptions<AppDbContext> options = new();
        private string caminhoDoArquivo;
        private readonly string caminhoTests = Path.Join("..", "..", "..", "..", "test");


        public RodoviaServiceTest()
        {
            caminhoDoArquivo = Path.Join(caminhoTests, "Stub", "planilhaExemplo.csv");
            mockRodoviaRepositorio = new();
            mockDb = new (options);
            rodoviaService = new RodoviaService(mockRodoviaRepositorio.Object, mockDb.Object);
        }

        [Fact]
        public void CadastrarRodoviaViaPlanilha_QuandoPlanilhaForPassadaENaoTiverDado_NaoDevePassarPeloRepositorio()
        {
            Assert.Throws<ArgumentNullException>(() => rodoviaService.CadastrarRodoviaViaPlanilha(null));
        }

        [Fact]
        public void CadastrarRodoviaViaPlanilha_QuandoForChamado_DeveChamarORepositorio()
        {
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
            caminhoDoArquivo = Path.Join(caminhoTests, "Stub", "planilha_tamanho_max.csv");

            MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(caminhoDoArquivo));

            bool resultado = rodoviaService.SuperaTamanhoMaximo(memoryStream);

            Assert.True(resultado);
        }
    }
}