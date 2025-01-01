namespace UrWave.Infrastructure.DI;

using Microsoft.Extensions.DependencyInjection;

using UrWave.Domain.AggregateModels.ProductAggregate;
using UrWave.Infrastructure.Repositories.Product;

public static class DependenciesConfigurator
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddServices();

        services.AddMediator();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
    }

    private static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        });
    }
}