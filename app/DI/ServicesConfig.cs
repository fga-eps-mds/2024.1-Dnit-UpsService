using app.Entidades;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Interfaces;

namespace app.DI
{
    public static class ServicesConfig
    {
        public static void AddConfigServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(optionsBuilder => optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgreSql")));

            services.AddScoped<IUpsService, UpsService>();
            services.AddScoped<ISinistroService, SinistroService>();
            services.AddScoped<IRodoviaService, RodoviaService>();

            services.AddControllers(o => o.Filters.Add(typeof(HandleExceptionFilter)));
        }
    }
}
