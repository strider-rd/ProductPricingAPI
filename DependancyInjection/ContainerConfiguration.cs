using Data;
using Services;

namespace ConfigureContainers
{
  public static class ContainerConfiguration
  {
    public static void ConfigureContainers(this IServiceCollection services)
    {
      services.AddSingleton<IDataService, DataService>();
      services.AddTransient<IProductService, ProductService>();
    }
  }
}