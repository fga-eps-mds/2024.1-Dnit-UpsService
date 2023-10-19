using api.Escolas;
using app.Entidades;
using Repositorio.Interfaces;
using Stub;
using test.Fixtures;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace test
{
    public class SinistroRepositorioTest : TestBed<Base>
    {
        readonly ISinistroRepositorio sinistroRepositorio;
        readonly AppDbContext db;

        public SinistroRepositorioTest(ITestOutputHelper testOutputHelper, Base fixture) : base(testOutputHelper, fixture)
        {
            db = fixture.GetService<AppDbContext>(testOutputHelper)!;
            sinistroRepositorio = fixture.GetService<ISinistroRepositorio>(testOutputHelper)!;
        }

        [Fact]
        public async Task ListarPaginadaAsync_QuandoPaginado_ListaDevidamentePaginada()
        {
            var sinistroDb = db.PopulaSinistros(11);
            var filtro = new PesquisaSinistroFiltro
            {
                Pagina = 1,
                ItemsPorPagina = 2
            };

            var lista = await sinistroRepositorio.ListarPaginadaAsync(filtro);

            Assert.Equal(sinistroDb.Count, lista.Total);
            Assert.Equal(filtro.Pagina, lista.Pagina);
            Assert.Equal(6, lista.TotalPaginas);
            Assert.Equal(filtro.ItemsPorPagina, lista.Items.Count);
        }

        [Fact]
        public async Task ListarPaginadaAsync_QuandoPedirPaginaNdeM_RetornaPaginaN()
        {
            var pagina = 5;
            var totalItems = 20;
            db.PopulaSinistros(totalItems);
            var filtro = new PesquisaSinistroFiltro
            {
                Pagina = pagina,
                ItemsPorPagina = 10
            };

            var lista = await sinistroRepositorio.ListarPaginadaAsync(filtro);

            Assert.Equal(pagina, lista.Pagina);
            Assert.Equal(filtro.ItemsPorPagina, lista.ItemsPorPagina);
        }

        [Fact]
        public async Task ListarPaginadaAsync_QuandoDivisaoNaoInteira_UltimaPaginaTemMenosItemsQueItemsPorPagina()
        {
            db.PopulaSinistros(7);
            var filtro = new PesquisaSinistroFiltro
            {
                Pagina = 2,
                ItemsPorPagina = 5
            };

            var lista = await sinistroRepositorio.ListarPaginadaAsync(filtro);

            Assert.Equal(2, lista.Items.Count);
            Assert.True(2 < filtro.ItemsPorPagina);
        }

        [Fact]
        public async Task ListarPaginadaAsync_QuandoItemsPedidosMaiorQueTotaldeItems_RetonaTodosItems()
        {
            var sinistroDb = db.PopulaSinistros(10);
            var filtro = new PesquisaSinistroFiltro
            {
                Pagina = 1,
                ItemsPorPagina = 20
            };

            var lista = await sinistroRepositorio.ListarPaginadaAsync(filtro);

            Assert.Equal(sinistroDb.Count, lista.Total);
            Assert.Equal(filtro.ItemsPorPagina, lista.ItemsPorPagina);
            Assert.Equal(10, lista.Items.Count);
        }

        [Fact]
        public async Task ListarPaginadaAsync_QuandoPaginaPedidaNaoExistir_RetonaListaVazia()
        {
            db.PopulaSinistros(10);
            var filtro = new PesquisaSinistroFiltro
            {
                Pagina = 4,
                ItemsPorPagina = 20
            };

            var lista = await sinistroRepositorio.ListarPaginadaAsync(filtro);

            Assert.Empty(lista.Items);
        }

        public new void Dispose()
        {
            db.Clear();
        }
    }
}