using app.DI;
using Microsoft.Extensions.Options;
using Service.Interfaces;

namespace test.Mock
{
    public class EscolaServiceMock : IEscolaService
    {
        private readonly HttpClient httpClient;
        private readonly string host;
        private readonly string calcularRanqueEndpoint = "/api/ranque/escolas/novo";

        public EscolaServiceMock(HttpClient _httpClient, IOptions<EscolaServiceConfig> config)
        {
            host = config.Value.Host;
            httpClient = _httpClient;
            httpClient.BaseAddress = new Uri("http://localhost");
        }

        public async Task CalcularNovoRanque()
        {
            await Task.Run(() => { });
        }
    }
}