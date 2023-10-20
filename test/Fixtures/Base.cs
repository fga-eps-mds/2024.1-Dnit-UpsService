using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;

using app.Entidades;
using Repositorio;
using Repositorio.Interfaces;
using app.Controllers;
using Service.Interfaces;
using Service;

namespace test.Fixtures
{
    public class Base : TestBedFixture
    {
        protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
        {
            // Para evitar a colisão durante a testagem paralela, o nome deve 
            // ser diferente para cada classe de teste
            var nome = "DbEmMoria" + Random.Shared.Next().ToString();
            services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase(nome));

            services.AddScoped<ISinistroRepositorio, SinistroRepositorio>();
            services.AddScoped<IRodoviaRepositorio, RodoviaRepositorio>();

            services.AddScoped<ISinistroService, SinistroService>();

            services.AddScoped<SinistroController>();
        }

        protected override ValueTask DisposeAsyncCore() => new();

        protected override IEnumerable<TestAppSettings> GetTestAppSettings()
        {
            yield return new() { Filename = "appsettings.json", IsOptional = false };
        }
    }
}