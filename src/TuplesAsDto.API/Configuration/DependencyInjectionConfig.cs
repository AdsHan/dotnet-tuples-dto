using Microsoft.EntityFrameworkCore;
using TuplesAsDto.API.Application.Services;
using TuplesAsDto.API.Data;
using TuplesAsDto.API.Data.Repositories;

namespace TuplesAsDto.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CatalogDbContext>(options => options.UseInMemoryDatabase("CatalogDB"));

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddTransient<ProductPopulateService>();

        return services;
    }
}
