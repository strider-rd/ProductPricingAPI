using Entities;
using Microsoft.EntityFrameworkCore;
using Models;
using Newtonsoft.Json;

namespace Data
{
  public class DataGenerator
  {
    private static string filePath { get {return "customer-data.json"; } }

    public static void InitData(IServiceProvider  serviceProivder)
    {
      using var context = new RepositoryContext(serviceProivder.GetRequiredService<DbContextOptions<RepositoryContext>>());

      if (context.Products.Any())
      {
        return; //Data is already added;
      }

      using StreamReader stream = new StreamReader(filePath);
      string json = stream.ReadToEnd();
      
      ProductRoot productData = JsonConvert.DeserializeObject<ProductRoot>(json);
      
      foreach (var item in productData.products)
      {
        item.ProductId = Guid.NewGuid();
      }
      
      context.Products.AddRange(productData.products);

      context.SaveChanges();

      ICollection<SpecificPrices> specificPrices = new List<SpecificPrices>();
      specificPrices = productData.specificPrices;

      foreach (var item in specificPrices)
      {
        foreach (var sp in item.products)
        {
          var productInContext = context.Products.FirstOrDefault(x => x.ean == sp.ean);
          if(productInContext == null) return;

          CustomerProduct customerProduct = new CustomerProduct()
          {
            CustomerProductId = Guid.NewGuid(),
            customer = item.customer,
            ProductId = productInContext.ProductId,
            price = sp.price
          };
        }
      }

      context.SaveChanges();
    }
  }
}