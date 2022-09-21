using Entities;

namespace Services
{
  public interface IProductService
  {
    IEnumerable<Product> GetProducts();
    IQueryable<Product> GetProductById(string ean);
    Product CreateNewProduct(Product newProduct);
    void UpdateProduct(Product updateProduct);
    void DeleteProductById(Product product);
  }
}