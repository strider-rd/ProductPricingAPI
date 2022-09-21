using Entities;
using Repositories;

namespace Services
{
  public class ProductService : IProductService
  {
    public IProductRepository _productRepository { get; }

    public ProductService(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    public IEnumerable<Product> GetProducts()
    {
      return _productRepository.FindAll();
    }

    public IQueryable<Product> GetProductById(string ean)
    {
      return _productRepository.FindByCondition(x => x.ean == ean);
    }

    public Product CreateNewProduct(Product newProduct) =>
      _productRepository.Create(newProduct);

    public void UpdateProduct(Product updateProduct) => 
      _productRepository.Update(updateProduct);

    public void DeleteProductById(Product product) => 
      _productRepository.Delete(product);
  }
}