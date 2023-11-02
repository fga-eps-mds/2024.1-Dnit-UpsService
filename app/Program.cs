using app.DI;
using app.Entidades;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(7085);
});

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "UpsService",
        Description = "Microserivo UpsService"
    });
});

builder.Services.AddConfigServices(builder.Configuration);

builder.Services.AddConfigRepositorios();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors("AllowAllOrigins");

app.UseSwagger();

app.UseSwaggerUI();

//app.UseHttpsRedirection();
// Vai ser deprecado
app.UseHangfireServer();
app.UseHangfireDashboard();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    dbContext.Database.Migrate();
}

app.Run();

BackgroundJob.Enqueue(() => Console.WriteLine("Hello world!"));
BackgroundJob.Enqueue(() => Console.WriteLine("Hello world!"));

using (var server = new BackgroundJobServer()) {
    Console.ReadLine();
}


/*
UseHangfireServer is obsolete AddHangfireServer extension method instead in the ConfigureServices method
*/