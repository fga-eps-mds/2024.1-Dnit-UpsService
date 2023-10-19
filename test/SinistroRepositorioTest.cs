using app.Entidades;
using Repositorio.Interfaces;
using test.Fixtures;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace test
{
    public class SinistroRepositorioTest : TestBed<Base>
    {
         ISinistroRepositorio sinistroRepositorio;
         AppDbContext db;

        public SinistroRepositorioTest(ITestOutputHelper testOutputHelper, Base fixture) : base(testOutputHelper, fixture)
        {
            db = fixture.GetService<AppDbContext>(testOutputHelper)!;
            sinistroRepositorio = fixture.GetService<ISinistroRepositorio>(testOutputHelper)!;
        }

        [Fact]
        public async Task ListarPaginadaAsync() {
            await Task.Run(() => {});
        }
    }
}