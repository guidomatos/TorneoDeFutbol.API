
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TorneoDeFutbol.Application.Common.Interfaces;
using TorneoDeFutbol.Infrastructure.Context;
using TorneoDeFutbol.Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastuctureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TorneoDeFutbolDbContext> (options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
        ));

        services.AddTransient<IEquipoService, EquipoService>();
        services.AddTransient<IProfesionService, ProfesionService>();
        services.AddTransient<ITorneoService, TorneoService>();

        return services;
    }
}