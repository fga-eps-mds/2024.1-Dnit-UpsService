using app.Controllers;
using app.Entidades;
using auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stub;
using test.Fixtures;
using Xunit.Abstractions;

namespace test
{
    public class RodoviaControllerTest : AuthTest
    {
        readonly AppDbContext db;
        readonly RodoviaController rodoviaController;

        readonly string caminhoStub = Path.Join("..", "..", "..", "..", "test", "Stub");

        public RodoviaControllerTest(ITestOutputHelper testOutputHelper, Base fixture) : base(testOutputHelper, fixture)
        {
            db = fixture.GetService<AppDbContext>(testOutputHelper)!;
            rodoviaController = fixture.GetService<RodoviaController>(testOutputHelper)!;

            AutenticarUsuario(rodoviaController);
        }

        [Fact]
        public async Task EnviarPlanilhaAsync_QuandoFormatoInvalido_RetornaBadRequest()
        {
            var caminhoArquivo = Path.Join(caminhoStub, "ExemploSin.csv");
            var conteudo = File.ReadAllBytes(caminhoArquivo);
            var memoryStream = new MemoryStream(File.ReadAllBytes(caminhoArquivo));
            var arquivo = new FormFile(memoryStream, 0, conteudo.Length, "planilha", "");
            arquivo.Headers = new HeaderDictionary();
            arquivo.Headers.ContentType = "application/json";

            var resultado = await rodoviaController.EnviarPlanilhaAsync(arquivo);
            var message = (resultado as BadRequestObjectResult)?.Value as string;

            Assert.IsType<BadRequestObjectResult>(resultado);
            Assert.Equal("Formato deve CSV", message);
        }

        [Fact]
        public async Task EnviarPlanilhaAsync_QuandoNaoTiverPermissao_DeveBloquear()
        {
            var caminhoArquivo = Path.Join(caminhoStub, "ExemploSin.csv");
            var conteudo = File.ReadAllBytes(caminhoArquivo);
            var memoryStream = new MemoryStream(File.ReadAllBytes(caminhoArquivo));
            var arquivo = new FormFile(memoryStream, 0, conteudo.Length, "planilha", "");
            arquivo.Headers = new HeaderDictionary();
            arquivo.Headers.ContentType = "application/json";

            AutenticarUsuario(rodoviaController, permissoes: new());
            await Assert.ThrowsAsync<AuthForbiddenException>(async () => await rodoviaController.EnviarPlanilhaAsync(arquivo));
        }

        [Fact]
        public async Task EnviarPlanilhaAsync_QuandoArquivoMuitoGrande_RetornaBadRequest()
        {
            var caminhoArquivo = Path.Join(caminhoStub, "planilha_tamanho_max.csv");
            var conteudo = File.ReadAllBytes(caminhoArquivo);
            var memoryStream = new MemoryStream(conteudo);
            var arquivo = new FormFile(memoryStream, 0, conteudo.Length, "planilha", "planilha.csv");
            arquivo.Headers = new HeaderDictionary();
            arquivo.Headers.ContentType = "text/csv";

            var resultado = await rodoviaController.EnviarPlanilhaAsync(arquivo);
            var message = (resultado as BadRequestObjectResult)?.Value as string;

            Assert.IsType<BadRequestObjectResult>(resultado);
            Assert.Equal("Tamanho máximo de arquivo ultrapassado", message);
        }

        [Fact]
        public async Task EnviarPlanilhaAsync_QuandoArquivoVazio_RetornaBadRequest()
        {
            var conteudo = Array.Empty<byte>();
            var memoryStream = new MemoryStream(conteudo);
            var arquivo = new FormFile(memoryStream, 0, conteudo.Length, "planilha", "");
            arquivo.Headers = new HeaderDictionary();
            arquivo.Headers.ContentType = "text/csv";

            var resultado = await rodoviaController.EnviarPlanilhaAsync(arquivo);
            var message = (resultado as BadRequestObjectResult)?.Value as string;

            Assert.IsType<BadRequestObjectResult>(resultado);
            Assert.Equal("Arquivo vazio", message);
        }

        [Fact]
        public async Task EnviarPlanilhaAsync_QuandoArquivoNormal_RetornaOk()
        {
            var caminhoArquivo = Path.Join(caminhoStub, "ExemploRodovia.csv");
            var conteudo = File.ReadAllBytes(caminhoArquivo);
            var memoryStream = new MemoryStream(conteudo);
            var arquivo = new FormFile(memoryStream, 0, conteudo.Length, "planilha", "planilha.csv");
            arquivo.Headers = new HeaderDictionary();
            arquivo.Headers.ContentType = "text/csv";

            var resultado = await rodoviaController.EnviarPlanilhaAsync(arquivo);

            Assert.IsType<OkResult>(resultado);
        }

        internal new void Dispose()
        {
            db.Clear();
        }
    }
}