using Data;
using Models;

namespace Services
{
  public class ProductService : IProductService
  {
    private IDataService _dataService { get; }
    public ProductService(IDataService dataService)
    {
      _dataService = dataService;
    }

    public ProductRoot GetProducts()
    {
      return _dataService.GetProducts();
    }

    public Product GetProductById(string ean)
    {
      return _dataService.GetProductById(ean);
    }

    public Product CreateNewProduct(Product newProduct)
    {
      return _dataService.CreateNewProduct(newProduct);
    }

    public Product UpdateProduct(Product updatedProduct)
    {
      return _dataService.UpdateExistingProduct(updatedProduct);
    }

    public bool DeleteProductById(string ean)
    {
      return _dataService.DeleteProductById(ean);
    }
  }
}