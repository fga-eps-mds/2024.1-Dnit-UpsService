using Repositorio;
using Repositorio.Interfaces;

namespace app.DI
{
    public static class RepositoriosConfig
    {
        public static void AddConfigRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IUpsRepositorio, UpsRepositorio>();
            services.AddScoped<IRodoviaRepositorio, RodoviaRepositorio>();
            services.AddScoped<ISinistroRepositorio, SinistroRepositorio>();
        }
    }
}
