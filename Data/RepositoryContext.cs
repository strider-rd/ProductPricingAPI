using Entities;
using Microsoft.EntityFrameworkCore;
using Models;
using Newtonsoft.Json;

namespace Data
{
  public class RepositoryContext : DbContext
  {
    public string filePath { get {return "customer-data.json"; } }
    public RepositoryContext(DbContextOptions options) : base(options)
    {
      // InitializeData();
    }

    private void InitializeData()
    {
      using StreamReader stream = new StreamReader(filePath);
      string json = stream.ReadToEnd();
      
      ProductRoot productData = JsonConvert.DeserializeObject<ProductRoot>(json);
      
      foreach (var item in productData.products)
      {
        item.ProductId = Guid.NewGuid();
      }
      
      Products.AddRange(productData.products);

      ICollection<SpecificPrices> specificPrices = new List<SpecificPrices>();
      specificPrices = productData.specificPrices;

      foreach (var item in specificPrices)
      {
        foreach (var sp in item.products)
        {
          var productInContext = Products.FirstOrDefault(x => x.ean == sp.ean);
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

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<CustomerProduct> CustomerProducts { get; set; }
  }
}