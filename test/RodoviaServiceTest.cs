using Moq;
using service;
using repositorio;
using service.Interfaces;
using repositorio.Interfaces;
using dominio;
using test.Stub;

namespace test
{
    public class RodoviaServiceTest
    {
        [Fact]
        public void CadastrarRodoviaViaPlanilha_QuandoPlanilhaForPassada_DevePassarPeloRepositorio()
        {
            Mock<IRodoviaRepositorio> mockRodoviaRepositorio = new();
            IRodoviaService rodoviaService = new RodoviaService(mockRodoviaRepositorio.Object);
            var memoryStream = new MemoryStream();

            rodoviaService.CadastrarRodoviaViaPlanilha(memoryStream);
            mockRodoviaRepositorio.Verify(mock => mock.CadastrarRodovia(It.IsAny<RodoviaDTO>()), Times.Never);
        }
    }

    [Fact]
    public void SuperaTamanhoMaximo_QuandoPlanilhaComTamanhoMaiorQueOMaximoForPassada_DeveRetornarTrue()
    {
        Mock<IRodoviaRepositorio> mockRodoviaRepositorio = new();
        IRodoviaService rodoviaService = new RodoviaService(mockRodoviaRepositorio.Object);

        string caminhoArquivo = ;

        MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(caminhoArquivo));

        bool resultado = rodoviaService.SuperaTamanhoMaximo(memoryStream);

        Assert.True(resultado);
    }

}