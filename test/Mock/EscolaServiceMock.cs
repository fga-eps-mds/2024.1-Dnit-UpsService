using Service.Interfaces;

namespace test.Mock
{
    public class EscolaServiceMock : IEscolaService
    {
        public async Task CalcularNovoRanque()
        {
            await Task.Run(() => {});
        }
    }
}