using Models;

namespace Services
{
  public interface IProductService
  {
    ProductRoot GetProducts();
    Product GetProductById(string ean);
    Product CreateNewProduct(Product newProduct);
    Product UpdateProduct(Product updateProduct);
    bool DeleteProductById(string ean);
  }
}