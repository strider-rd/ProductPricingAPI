using Models;

namespace Data
{
  public interface IDataService
  {
    ProductRoot GetProducts();
    Product GetProductById(string ean);
    Product CreateNewProduct(Product newProduct);
    Product UpdateExistingProduct(Product updatedProduct);
    bool DeleteProductById(string ean);
  }
}