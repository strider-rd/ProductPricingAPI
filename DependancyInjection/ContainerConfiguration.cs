using Repositories;
using Services;

namespace ConfigureContainers
{
  public static class ContainerConfiguration
  {
    public static void ConfigureContainers(this IServiceCollection services)
    {
      services.AddTransient<IProductService, ProductService>();
      services.AddScoped<ICustomerProductRepository, CustomerProductRepository>();
      services.AddScoped<IProductRepository, ProductRepository>();
    }
  }
}