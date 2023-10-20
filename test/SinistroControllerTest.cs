using api;
using api.Escolas;
using app.Controllers;
using app.Entidades;
using app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stub;
using test.Fixtures;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace test
{
    public class SinistroControllerTest : TestBed<Base>
    {
        readonly AppDbContext db;
        readonly SinistroController sinistroController;
        readonly string caminhoStub = Path.Join("..", "..", "..", "..", "test", "Stub");

        public SinistroControllerTest(ITestOutputHelper testOutputHelper, Base fixture) : base(testOutputHelper, fixture)
        {
            db = fixture.GetService<AppDbContext>(testOutputHelper)!;
            sinistroController = fixture.GetService<SinistroController>(testOutputHelper)!;
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

            var resultado = await sinistroController.EnviarPlanilhaAsync(arquivo);
            var message = (resultado as BadRequestObjectResult)?.Value as string;

            Assert.IsType<BadRequestObjectResult>(resultado);
            Assert.Equal("Formato deve CSV", message);
        }

        [Fact]
        public async Task EnviarPlanilhaAsync_QuandoArquivoMuitoGrande_RetornaBadRequest()
        {
            var caminhoArquivo = Path.Join(caminhoStub, "ExemploSinistroTamanhoMaximo.csv");
            var conteudo = File.ReadAllBytes(caminhoArquivo);
            var memoryStream = new MemoryStream(conteudo);
            var arquivo = new FormFile(memoryStream, 0, conteudo.Length, "planilha", "planilha.csv");
            arquivo.Headers = new HeaderDictionary();
            arquivo.Headers.ContentType = "text/csv";

            var resultado = await sinistroController.EnviarPlanilhaAsync(arquivo);
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

            var resultado = await sinistroController.EnviarPlanilhaAsync(arquivo);
            var message = (resultado as BadRequestObjectResult)?.Value as string;

            Assert.IsType<BadRequestObjectResult>(resultado);
            Assert.Equal("Arquivo vazio", message);
        }

        [Fact]
        public async Task EnviarPlanilhaAsync_QuandoArquivoNormal_RetornaOk()
        {
            var caminhoArquivo = Path.Join(caminhoStub, "ExemploSin.csv");
            var conteudo = File.ReadAllBytes(caminhoArquivo);
            var memoryStream = new MemoryStream(conteudo);
            var arquivo = new FormFile(memoryStream, 0, conteudo.Length, "planilha", "planilha.csv");
            arquivo.Headers = new HeaderDictionary();
            arquivo.Headers.ContentType = "text/csv";

            var resultado = await sinistroController.EnviarPlanilhaAsync(arquivo);

            Assert.IsType<OkResult>(resultado);
        }

        internal new void Dispose()
        {
            db.Clear();
        }
    }
}