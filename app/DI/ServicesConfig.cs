using auth;
using app.Entidades;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Interfaces;
using Hangfire;
using Hangfire.PostgreSql;

namespace app.DI
{
    public static class ServicesConfig
    {
        public static void AddConfigServices(this IServiceCollection services, IConfiguration configuration)
        {
            var mode = Environment.GetEnvironmentVariable("MODE");
            var conexao = mode == "container" ? "PostgreSqlDocker" : "PostgreSql";
            services.AddDbContext<AppDbContext>(optionsBuilder => optionsBuilder.UseNpgsql(configuration.GetConnectionString(conexao)));

            services.AddScoped<IUpsService, UpsService>();
            services.AddScoped<ISinistroService, SinistroService>();
            services.AddScoped<IRodoviaService, RodoviaService>();

            services.AddControllers(o => o.Filters.Add(typeof(HandleExceptionFilter)));

            services.AddAuth(configuration);

            services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(c => 
                    c.UseNpgsqlConnection(configuration.GetConnectionString("Hangfire")))
            );
            services.AddHangfireServer();
            // precisa mesmo ou é só um exemplo???
            // services.AddMvc();
        }
    }
}
