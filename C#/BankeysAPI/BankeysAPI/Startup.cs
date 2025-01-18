using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Configuração do DbContext com Npgsql
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(DatabaseConfig.ConnectionString)); // Supondo que DatabaseConfig.ConnectionString esteja configurado corretamente
        services.AddControllers();

        // Configuração do Swagger para documentação da API
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app)
    {
        // Configuração do Swagger
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bankeys API v1"));

        // Configuração do pipeline de requisições
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}