using Moq;
using service;
using repositorio;
using service.Interfaces;
using repositorio.Interfaces;
using dominio;
using test.Stub;

namespace test
{
    public class SinistroServiceTest
    {
        [Fact]
        public void CadastrarRodoviaViaPlanilha_QuandoPlanilhaForPassada_DevePassarPeloRepositorio()
        {
            Mock<ISinistroRepositorio> mockSinistroRepositorio = new();
            ISinistroService SinistroService = new SinistroService(mockSinistroRepositorio.Object);
            var memoryStream = new MemoryStream();

            sinistroService.CadastrarSinistroViaPlanilha(memoryStream);
            mockSinistroRepositorio.Verify(mock => mock.CadastrarSinistro(It.IsAny<SinistroDTO>()), Times.Never);
        }
    }

    [Fact]
    public void SuperaTamanhoMaximo_QuandoPlanilhaComTamanhoMaiorQueOMaximoForPassada_DeveRetornarTrue()
    {
        Mock<ISinistroRepositorio> mockSinistroRepositorio = new();
        ISinistroService sinistroService = new SinistroService(mockSinistroRepositorio.Object);

        string caminhoArquivo = "../../../Stub/planilhaExemploSinistro.csv";

        MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(caminhoArquivo));

        bool resultado = sinistroService.SuperaTamanhoMaximo(memoryStream);

        Assert.True(resultado);
    }

}